using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class FirebaseTestScript : MonoBehaviour {

    DatabaseReference mDatabaseRef;

	// Use this for initialization
	void Start () {

        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://re-active.firebaseio.com/");

        // Get the root reference location of the database.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void onButtonClick()
    {
        writeNewUser("1", "Bob", "bob@bob.com");
        Debug.Log("Boop");
    }

    private void writeNewUser(string userId, string name, string email)
    {
        //User user = new User(name, email);
        //string json = JsonUtility.ToJson(user);
        //
        //mDatabaseRef.Child("users").Child(userId).Child("username").SetValueAsync(name);
    }

}
