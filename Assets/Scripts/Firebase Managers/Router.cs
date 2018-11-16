using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Router : MonoBehaviour {

    private static DatabaseReference dbRef;

    private void Awake()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://re-active.firebaseio.com/");
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;

    }

    public static DatabaseReference Users()
    {
        return dbRef.Child("users");
    }

    public static DatabaseReference PlayerStats(string uid)
    {
        return dbRef.Child("stats").Child(uid);
    }

    public static DatabaseReference PlayerInventory(string uid)
    {
        return dbRef.Child("inventory").Child(uid);
    }

    public static DatabaseReference PlayerEquipment(string uid)
    {
        return dbRef.Child("equipment").Child(uid);
    }

    public static DatabaseReference UserWithUID(string uid)
    {
        return dbRef.Child("users").Child(uid);
    }


}
