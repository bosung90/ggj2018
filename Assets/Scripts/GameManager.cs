using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

	public static GameManager Instance;
//	public Dictionary<int, Role> playerRoles = new Dictionary<int, Role>();
	public Dictionary<int, List<Action>> playerActions = new Dictionary<int, List<Action>>();

	public enum Role
	{
		Mobility,
		Hacker,
		Combat,
		Transmitter
	}

	public struct Action {
		public Role role;
		public int point;
		public bool isUsed;
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
	public void RpcInitPlayerRoles(Dictionary<int, Role> playerRoles){
//		this.playerRoles = playerRoles;
		foreach (int connectionId in playerRoles.Keys) {
			List<Action> actions = new List<Action> ();
			actions.Add (new Action{ role = Role.Mobility, point = 1 });
			actions.Add (new Action{ role = Role.Mobility, point = 2 });
			actions.Add (new Action{ role = Role.Hacker, point = 1 });
			actions.Add (new Action{ role = Role.Hacker, point = 2 });
			actions.Add (new Action{ role = Role.Combat, point = 1 });
			actions.Add (new Action{ role = Role.Combat, point = 2 });
			actions.Add (new Action{ role = Role.Transmitter, point = 1 });
			actions.Add (new Action{ role = Role.Transmitter, point = 2 });

			Role role = playerRoles [connectionId];
			actions.Add (new Action{ role = role, point = 3 });

			playerActions.Add (connectionId, actions);
		}
	}
}
