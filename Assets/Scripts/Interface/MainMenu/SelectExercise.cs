using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectExercise : MonoBehaviour {

    Button btnExercisePage;
    public int sceneNum = 0;

	// Use this for initialization
	void Start () {
        btnExercisePage = GetComponent<Button>();
        btnExercisePage.onClick.AddListener(onExercisePageClick);

	}
	
    void onExercisePageClick()
    {
        SceneManager.LoadScene(sceneNum);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
