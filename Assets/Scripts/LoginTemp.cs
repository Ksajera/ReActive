using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginTemp : MonoBehaviour {

    int uid;

    string username;
    string password;

    public Text txtUsername;
    public Text txtPassword;

    public Button btnLogin;
    public Button btnRegister;

    User userDylan;
    User userJosh;
    User userJk;

    List<string> armourList = new List<string>();
    List<string> weaponList = new List<string>();

	void Awake () {

        btnLogin.onClick.AddListener(Login);
        btnRegister.onClick.AddListener(Register);

        //ARMOUR LIST
        armourList.Add("armourSprite1");
        armourList.Add("armourSprite2");
        armourList.Add("armourSprite3");

        //WEAPON LIST
        weaponList.Add("weaponSprite1");
        weaponList.Add("weaponSprite2");
        weaponList.Add("weaponSprite3");
    }

    // Update is called once per frame
    void Update () {
		
	}

    void Login()
    {
        if(username == "dylan@gmail.com" && password == "lmao")
        {
            User userDylan = new User(1, username);
            uid = userDylan.uid;
        }
        if(username == "josh@gmail.com" && password == "lmao")
        {
            User userJosh = new User(2, username);
            uid = userJosh.uid;
        }
        if (username == "jk@gmail.com" && password == "lmao")
        {
            User userJk = new User(3, username);
            uid = userJk.uid;
        }
    }

    void Register()
    {

    }
}
