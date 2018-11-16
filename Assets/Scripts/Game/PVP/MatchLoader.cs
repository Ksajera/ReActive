using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MatchLoader : NetworkBehaviour {

    Image imgLoading;
    Text txtLoading;
    Button btnCancel;

	// Use this for initialization
	void Start () {

        //imgLoading = gameObject.GetComponent<Image>();
        //txtLoading = gameObject.GetComponentInChildren<Text>();
        //btnCancel = gameObject.GetComponentInChildren<Button>();

        Load();

	}

    void Load()
    {
        if (!BattleManager.singleton.ready)
        {
            Invoke("Load", Constants.WAIT_DELAY);
            return;
        }


        //imgLoading.enabled = false;
        //txtLoading.enabled = false;
        //btnCancel.enabled = false;
        Destroy(gameObject);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
