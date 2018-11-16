using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CountdownTimer : NetworkBehaviour {

    public double secondsLeft;
    Text txt_Countdown;

    public bool ready;

	// Use this for initialization
	void Start () {

        //Assume that countdown timer script is attached to corresponding text object.
        txt_Countdown = gameObject.GetComponent<Text>();
        secondsLeft = Constants.TIMER_READY_DURATION;

        //Invokes function every one second.
        InvokeRepeating("Countdown_Ready", 0, 1);
        ready = false;

	}

    void Countdown_Battle()
    {

        if (BattleManager.singleton.ready && ready)
        {
            secondsLeft--;

            if (secondsLeft < 0)
            {
                //Drop connection
                BattleManager.singleton.CountdownEnd();
                CancelInvoke("Countdown_Battle");
            }

            txt_Countdown.text = Mathf.Round((float)secondsLeft).ToString();
        }

    }

    void Countdown_Ready()
    {
        if (BattleManager.singleton.ready)
        {
            if (secondsLeft == Constants.TIMER_READY_DURATION)
            {
                txt_Countdown.text = "Ready?";
                secondsLeft--;

                return;
            }

            if (secondsLeft != 0)
            {
                txt_Countdown.text = ((int)secondsLeft).ToString();
                secondsLeft--;
            }

            else if (secondsLeft == 0)
            {
                txt_Countdown.text = "Start!";
                secondsLeft = Constants.MATCH_DURATION; //resets timer for match time limit.
                ready = true;

                CancelInvoke("Countdown_Ready"); //Stops invoking function
                InvokeRepeating("Countdown_Battle", 1, 1); //Repeatedly invokes countdown function every 1 seconds after 1 second.

            }

        }

        //OLD
        //if (secondsLeft > 3)
        //{
        //    txt_Countdown.text = "Ready?";
        //    secondsLeft--;
        //}
        //else if (secondsLeft > 0 && secondsLeft <= 3)
        //{
        //    txt_Countdown.text = secondsLeft.ToString();
        //    secondsLeft--;
        //}
        //else
        //{
        //    txt_Countdown.text = "Start!";
        //    secondsLeft = Constants.MATCH_DURATION;

        //    CancelInvoke("CountDown_Ready");
        //}
    }


}
