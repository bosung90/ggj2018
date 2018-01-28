using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CsNetworkManager : NetworkManager {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (NetworkServer.active)
        {
            Debug.Log("active");
        }
  
        if (!this.IsClientConnected() && !NetworkServer.active && this.matchMaker == null)
        {
            if (UnityEngine.Application.platform != RuntimePlatform.WebGLPlayer)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    this.StartServer();
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    this.StartHost();
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                this.StartClient();
            }
        }
        if (NetworkServer.active && this.IsClientConnected())
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                this.StopHost();
            }
        }

        
    }

    public void CreateRoom()
    {
        Debug.Log("Create");

        try
        {
           StartHost();
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
            throw;
        }

        if (!this.IsClientConnected() && !NetworkServer.active && this.matchMaker == null)
        {
            StartClient();

        }


    }

    public void JoinRoom()
    {
        Debug.Log("Join");

    }


}
