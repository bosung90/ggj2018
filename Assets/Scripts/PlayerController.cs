using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    [SyncVar]
    public Color _color;
    
    void Update()
	{
		if (!isLocalPlayer)
			return;

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
	}

    //sever -> client
	[ClientRpc]
	public void RpcSetPlayerColor(Color color) {

        _color = color;
        GetComponent<MeshRenderer> ().material.color = color;
        Debug.Log("RpcSetPlayerColor");


    }

    //client -> sever
    [Command]
    void CmdMakePlayer()
    {
        Debug.Log("cmd Make Plaeyr");
        NetworkServer.Spawn(this.gameObject);
    }
}