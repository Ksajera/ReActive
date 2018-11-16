using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
    public Button btnStart;

    // Use this for initialization
    void Start () {

        //if start button is not set in the inspector, set button to current attached object.
        if (btnStart == null)
        {
            btnStart = gameObject.GetComponent<Button>();
        }

        btnStart = btnStart.GetComponent<Button>();

        //OnClick listener
        btnStart.onClick.AddListener(GameStart);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Function to start the game
    public void GameStart()
    {
        //Loads scene after the Title Screen
        SceneManager.LoadScene(1);
    }
}
