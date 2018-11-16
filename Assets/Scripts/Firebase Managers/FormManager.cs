using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class FormManager : MonoBehaviour {

    public InputField emailInput;
    public InputField passwordInput;

    public Button btnSignup;
    public Button btnLogin;

    public Text statusText;

    public AuthManager authManager;

    void Awake()
    {
        //ToggleButtonStates(false);

        //Auth delegate subscriptions
        authManager.authCallback += HandleAuthCallback;

    }

    //validate email input
    //Regex pattern doesn't seem to work, will try again another time.
    //public void ValidateEmail()
    //{
    //    string email = emailInput.text;
    //    var regexPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
    //                    + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9]}\.([0-1]?[0-9])\{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
    //                    + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}"
    //                    + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

    //    if (email != "" && Regex.IsMatch(email, regexPattern))
    //    {
    //        ToggleButtonStates(true);
    //    }

    //    else
    //    {
    //        ToggleButtonStates(false);
    //    }

    //}

    //firebase methods
    public void OnSignUp()
    {
        authManager.SignUpNewUser(emailInput.text, passwordInput.text);
        print("Sign up");

    }

    public void OnLogin()
    {
        authManager.LoginExistingUser(emailInput.text, passwordInput.text);
        print("Login");
    }

    IEnumerator HandleAuthCallback(Task<Firebase.Auth.FirebaseUser> task, string operation) {
        if (task.IsFaulted || task.IsCanceled)
        {
            UpdateStatus("Sorry, there was an error creating your new account. Error: " + task.Exception);
        }

        else if (task.IsCompleted)
        {

            if (operation == "sign_up")
            {
                Firebase.Auth.FirebaseUser newPlayer = task.Result;
                Debug.LogFormat("Welcome to ReActive {0}!", newPlayer.Email);

                User user = new User(newPlayer.Email);
                DatabaseManager.sharedInstance.CreateNewPlayer(user, newPlayer.UserId);

                PlayerStats playerstats = new PlayerStats();
                DatabaseManager.sharedInstance.SetNewPlayerStats(playerstats, newPlayer.UserId);

            }

            //else if (operation == "login")
            //{
            //    Firebase.Auth.FirebaseUser user = task.Result;
            //    Debug.LogFormat("Welcome to ReActive {0}!", user.Email);
                
            //    GameManager.singleton.stats = DatabaseManager.GetPlayerStats(user.UserId);

            //}

            Firebase.Auth.FirebaseUser newUser = task.Result;
            UpdateStatus("Loading the game scene.");

            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("Main Menu");
        }
    }

    void OnDestroy()
    {
        authManager.authCallback -= HandleAuthCallback;
    }

    //utilities
    private void ToggleButtonStates(bool toState)
    {
        btnSignup.interactable = toState;
        btnLogin.interactable = toState;
    }

    private void UpdateStatus(string msg)
    {
        statusText.text = msg;
    }
}
