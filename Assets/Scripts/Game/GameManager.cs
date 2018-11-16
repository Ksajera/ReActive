using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;

    public PlayerStats stats;
    public PlayerInventory inventory;
    public PlayerEquipment equipment;

    bool ready = false;
    Firebase.FirebaseApp app;

    public ItemCategory CategoryWeapon;
    public ItemCategory CategoryArmour;

    //logging in
    public string username;

    void Awake()
    {
        if (singleton == null)
            singleton = this;

        else if (singleton != this)
            Destroy(gameObject);

        stats = new PlayerStats();
        inventory = new PlayerInventory();
        equipment = new PlayerEquipment();

        CategoryWeapon = new ItemCategory(Constants.CATEGORY_WEAPON, "weapons", "");
        CategoryArmour = new ItemCategory(Constants.CATEGORY_ARMOUR, "armours", "");
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp, i.e.
                //   app = Firebase.FirebaseApp.DefaultInstance;
                // where app is a Firebase.FirebaseApp property of your application class.

                app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here indicating that Firebase is ready to use by your
                // application.
                ready = true;

            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

}
