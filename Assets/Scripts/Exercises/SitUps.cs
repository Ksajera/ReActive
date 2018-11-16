using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SitUps : NetworkBehaviour {

    public Text txtCount;
    private Player player;

    private Vector3 gyroVal;
    float gyroX;

    private bool isMoving = false;
    private bool lastIsMoving = false;
    private bool ready;

    int countMotion = 0;
    int countSitUp = 0;

    public double max;
    public double min;



    void Awake()
    {
        //Checks if the script should be enabled for the current scene.
        if (!(SceneManager.GetActiveScene() == SceneManager.GetSceneByName(Constants.SCENE_SITUP_NAME)))
            return;

        Input.gyro.enabled = true;
        ready = false;
    }

    // Use this for initialization
    void Start () {

        max = Constants.GYRO_X_MAX;
        min = Constants.GYRO_X_MIN;

        //Assume that sensor script is to be attached to player gameobject.
        player = gameObject.GetComponent<Player>();

    }

    void FixedUpdate()
    {
        if (BattleManager.singleton.ready == true)
        {
            gyroVal = Input.gyro.rotationRate;
            gyroX = gyroVal.x;

            CalcSitup();
        }

    }

    void CalcSitup()
    {

        if (isLocalPlayer)
        {

            if (gyroX <= max && gyroX >= min) //around 0 range
            {
                isMoving = false;
                lastIsMoving = false;
            }
        
            else if ((gyroX > max || gyroX < min) && lastIsMoving == false) //out of 0 range
            {

                isMoving = true;
                lastIsMoving = true;

                countMotion += 1;

            }

            if (isMoving == false && countMotion == 2)
            {
                countSitUp += 1;
                countMotion = 0; //reset motion count back to 0 to begin detecting th enext situp

                //Calls attack command in player class.
                player.CmdAttack();

            }

        }

    }

    

}
