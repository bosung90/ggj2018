using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGJStartMenu : MonoBehaviour {

    /*
    private static GGJStartMenu _instance;
    private static GameObject _container;
    public static GGJStartMenu GetInstance()
    {
        if (!_instance)
        {
            GameObject container = new GameObject();
            container.name = "MyClassContainer";
            _instance = container.AddComponent(typeof(GGJStartMenu)) as GGJStartMenu;
        }
      
        return _instance;
    }

  */

    public List<GameObject> _scene = new List<GameObject>();
    public List<GameObject> _btn_job = new List<GameObject>();


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Scene_Active(int num)
    {
        num--;

        for (int i = 0; i< _scene.Count; ++i )
        {
            _scene[i].SetActive(false);
        }
        _scene[num].SetActive(true);
    }

    public void Select_Job(int num)
    {
       //선택하면, 다른ㅇ ㅐ가 있는지 일단 보고, 없으면 선택 
        for(int i = 0; i < _btn_job.Count -3; ++i)
        {
            //체크?
        }
        _btn_job[num].SetActive(false);
        num += 4;
        _btn_job[num].SetActive(true);
    }

}
