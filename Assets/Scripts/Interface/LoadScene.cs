using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void LoadSceneByName(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex > 0)
            SceneManager.LoadScene(currentSceneIndex - 1);

    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex > 0)
            SceneManager.LoadScene(currentSceneIndex + 1);

    }

}
