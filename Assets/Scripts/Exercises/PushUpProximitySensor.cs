using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PushUpProximitySensor : NetworkBehaviour {

    private Player player;

    public Text txtTimer;
    public Text txtCount;

    public Image background;
    public Color nearColor;
    public Color farColor;

    private int countPushUp = 0;

    // Use this for initialization
    void Start () {

        if (!(SceneManager.GetActiveScene() == SceneManager.GetSceneByName(Constants.SCENE_PUSHUP_NAME)))
            return;

        //Assume that sensor script is to be attached to player gameobject.
        player = gameObject.GetComponent<Player>();

        //Add the method to the onProximityChange delegate,
        //Method must have the signaure void MethodName(PAProximity.Proximity arg)
        PAProximity.onProximityChange += PushUpDetect;

    }

    void OnDestroy()
    {
        //When this object is destroyed (either by Destroy() or by loading a new level) the delegate MUST BE CLEANED UP!
        PAProximity.onProximityChange -= PushUpDetect;
    }

    /// <summary>
    /// Sets the scale by proximity.
    /// Method is added to the onProximityChange delegate so must return void and have a PAProximity.Proximity parameter
    /// </summary>
    /// <param name="arg">Argument.</param>
    //void proximTest(PAProximity.Proximity proximity)
    //{
    //    background.color = ((proximity == PAProximity.Proximity.NEAR) ? Color.black : Color.white);
    //    if (proximity == (PAProximity.Proximity.NEAR))
    //        countPushUp += 1;

    //    txtCount.text = countPushUp.ToString();
    //}

    void PushUpDetect(PAProximity.Proximity proximity)
    {
        if (proximity == (PAProximity.Proximity.NEAR) && isLocalPlayer)
        {
            player.CmdAttack();
        }

    }

}
