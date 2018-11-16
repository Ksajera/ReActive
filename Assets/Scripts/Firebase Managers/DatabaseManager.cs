using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class DatabaseManager : MonoBehaviour {

    public static DatabaseManager sharedInstance = null;

    void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
        else if (sharedInstance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://re-active.firebaseio.com/");

    }

    public void CreateNewPlayer(User user, string uid)
    {
        string userJSON = JsonUtility.ToJson(user);
        Router.UserWithUID(uid).SetRawJsonValueAsync(userJSON);

    }

    public void SetNewPlayerStats(PlayerStats playerstats, string uid)
    {
        string json = JsonUtility.ToJson(playerstats);
        Router.PlayerStats(uid).SetRawJsonValueAsync(json);

    }

    public void SetNewPlayerInventory(PlayerInventory inventory, string uid)
    {
        string json = JsonUtility.ToJson(inventory);
        Router.PlayerInventory(uid).SetRawJsonValueAsync(json);

    }

    public void SetNewPlayerEquipment(PlayerEquipment equipment, string uid)
    {
        string json = JsonUtility.ToJson(equipment);
        Router.PlayerEquipment(uid).SetRawJsonValueAsync(json);

    }

    public PlayerStats GetPlayerStats(string uid)
    {
        string json = "";
        Router.PlayerEquipment(uid).GetValueAsync().ContinueWith(task =>{
            if (task.IsFaulted)
            {
                Debug.Log("Kaboom");
            }

            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                json = snapshot.GetRawJsonValue();

            }
        });
        return JsonUtility.FromJson<PlayerStats>(json);
    }

    void GetUserInfo()
    {

    }
}
