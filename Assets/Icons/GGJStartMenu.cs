using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGJStartMenu : MonoBehaviour {

    private static GGJStartMenu _instance;
    private static GameObject _container;
    public static GGJStartMenu GetInstance()
    {
        if (!_instance)
        {
            _container = new GameObject();
            _container.name = "GGJStartMenu";
            _instance = _container.AddComponent(typeof(GGJStartMenu)) as GGJStartMenu;
        }
        return _instance;
    }

    public GameObject _btn_Start;
    public GameObject _btn_Rooms;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
