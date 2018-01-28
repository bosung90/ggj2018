using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public Dictionary<int, Role> playerRoles = new Dictionary<int, Role>();
	public Dictionary<int, List<Action>> playerActions = new Dictionary<int, List<Action>>();

	public enum Role
	{
		Mobility,
		Hacker,
		Combat,
		Transmitter
	}

	public struct Action {
		Role role;
		int point;
	}

	void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	[ClientRpc]
	public void InitPlayerRoles(Dictionary<int, Role> playerRoles){
		this.playerRoles = playerRoles;
		foreach (int connectionId in playerRoles.Keys) {
			
		}
	}
}
