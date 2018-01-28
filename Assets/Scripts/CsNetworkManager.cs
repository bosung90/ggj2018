using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class CsNetworkManager : NetworkManager
{

    public GameObject[] _spawn_position;
    public GGJStartMenu _menu;

    private NetworkClient _myClient;
    private Dictionary<Color, PlayerController> colorPlayerController = new Dictionary<Color, PlayerController>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("OnStartServer( )");
    }

    public override void OnStartClient(NetworkClient client)
    {
        base.OnStartClient(client);
        Debug.Log("OnStartClient()");
    }

    public override void OnStopClient()
    {
        base.OnStopClient();
        Debug.Log("OnStopClient()");
    }

    static int count = 0;  // 나중에 수정 
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        //if (count > _spawn_position.Length)
         //   return;

        Debug.Log("OnServerAddPlayer  : " + playerControllerId.ToString() + "  ddddd : " + conn.connectionId.ToString());

     
        GameObject newObject = Instantiate(playerPrefab) as GameObject;
        newObject.transform.SetParent(_spawn_position[count].transform);
        newObject.transform.localPosition = new Vector3();
        NetworkServer.AddPlayerForConnection(conn, newObject, playerControllerId);

        Color color = Color.black;
        if (conn.connectionId.Equals(0))
        {
            color = Color.red;
        }
        else if (conn.connectionId.Equals(1))
        {
            color = Color.blue;
        }
        else if (conn.connectionId.Equals(2))
        {
            color = Color.green;
        }
        else if (conn.connectionId.Equals(3))
        {
            color = Color.cyan;
        }
        else if (conn.connectionId.Equals(4))
        {
            color = Color.magenta;
        }
        else if (conn.connectionId.Equals(5))
        {
            color = Color.yellow;
        }
        PlayerController playerController = newObject.GetComponent<PlayerController>();

        colorPlayerController.Add(color, playerController);

        foreach (Color c in colorPlayerController.Keys)
        {
            var pc = colorPlayerController[c];
            pc.RpcSetPlayerColor(c);
        }
        count++;
        /*
     switch (count)
     {
         case 0: newObject.GetComponent<MeshRenderer>().material.color = Color.red; break;
         case 1: newObject.GetComponent<MeshRenderer>().material.color = Color.blue; break;
         case 2: newObject.GetComponent<MeshRenderer>().material.color = Color.cyan; break;
         case 3: newObject.GetComponent<MeshRenderer>().material.color = Color.yellow; break;
     }
     NetworkServer.AddPlayerForConnection(conn, newObject, playerControllerId);
     newObject.GetComponent<PlayerController>().RpcSetPlayerColor(newObject.GetComponent<MeshRenderer>().material.color);
     */
    }

    //server
    //user difine func
    public void SetupServer()
    {
        if (StartServer())
        {
            Debug.Log("SetupServer()");
            //  NetworkServer.RegisterHandler(MsgType.Connect, OnConnected);
        }
        else
        {
            if (!this.IsClientConnected() && !NetworkServer.active && this.matchMaker == null)
            {
                SetupClient();
                Debug.Log("SetupClient()");

            }
        }

        //--------
        if (null != _menu)
        {
            _menu.Scene_Active(2);
        }

    }
    //client 
    //user difine func
    public void SetupClient()
    {
        Debug.Log("SetupClient()");
        StartClient();

        _myClient = new NetworkClient();
        _myClient.Connect(this.networkAddress, this.networkPort);

    }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }


}
