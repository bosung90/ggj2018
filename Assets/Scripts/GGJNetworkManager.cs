using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class GGJNetworkManager : NetworkManager {

	private NetworkManager _networkManager;

	private Dictionary<Color, PlayerController> colorPlayerController = new Dictionary<Color, PlayerController>();

	void Awake() {
		this._networkManager = GetComponent<NetworkManager> ();
	}
		
	void Start () {
		this._networkManager.StartServer ();
		this._networkManager.StartClient ();
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		Debug.Log ("OnServerAddPlayer");
		var player = (GameObject)GameObject.Instantiate(this.playerPrefab, this._networkManager.GetStartPosition().position, Quaternion.identity);
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
		Color color = Color.black;
		if (conn.connectionId.Equals (0)) {
			color = Color.red;
		} else if (conn.connectionId.Equals (1)) {
			color = Color.blue;
		} else if (conn.connectionId.Equals (2)) {
			color = Color.green;
		} else if (conn.connectionId.Equals (3)) {
			color = Color.cyan;
		} else if (conn.connectionId.Equals (4)) {
			color = Color.magenta;
		} else if (conn.connectionId.Equals (5)) {
			color = Color.yellow;
		}
		PlayerController playerController = player.GetComponent<PlayerController> ();

		colorPlayerController.Add (color, playerController);

		foreach (Color c in colorPlayerController.Keys) {
			var pc = colorPlayerController [c];
			pc.RpcSetPlayerColor (c);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
