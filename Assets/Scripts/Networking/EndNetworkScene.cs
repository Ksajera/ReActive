using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndNetworkScene : NetworkBehaviour {

    Button btnChangeScene;

	// Use this for initialization
	void Start () {
        btnChangeScene = GetComponent<Button>();
        btnChangeScene.onClick.AddListener(OnEndSceneClick);
    }
	
    void OnEndSceneClick()
    {
        NetworkManager.singleton.StopClient();
        SceneManager.LoadScene("Main Menu");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
