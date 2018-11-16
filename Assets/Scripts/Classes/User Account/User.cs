using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class User
{

    PlayerStats stats = GameManager.singleton.stats;
    PlayerInventory inventory = GameManager.singleton.inventory;
    PlayerEquipment equipment = GameManager.singleton.equipment;

    public int uid;
    public string email;
    public string ign;

    public User()
    {
    }

    public User(string email)
    {
        this.email = email;
    }

    public User(int uid,string email)
    {
        this.uid = uid;
        this.email = email;

    }

    public void RegisterUser()
    {
        
    }

}
