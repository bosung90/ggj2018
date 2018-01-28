using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CsNetworkManager : NetworkManager {
    NetworkClient myClient;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
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

    //server
    //user difine func
    public void SetupServer()
    {
        bool hasStarted = StartServer();
        Debug.Log("SetupServer()");
        //  NetworkServer.RegisterHandler(MsgType.Connect, OnConnected);

        if (!this.IsClientConnected() && !NetworkServer.active && this.matchMaker == null)
        {
            SetupClient();
            Debug.Log("SetupClient()");
        }

     //   GGJStartMenu.GetInstance()._btn_Start.SetActive(true);
    }

    //client 
    //user difine func
    public void SetupClient()
    {
        Debug.Log("SetupClient()");
        StartClient();

        myClient = new NetworkClient();
		myClient.Connect(this.networkAddress, this.networkPort);

    }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }


}
