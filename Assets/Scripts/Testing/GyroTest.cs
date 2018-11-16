using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroTest : MonoBehaviour {

    private Vector3 gyroVal;
    private Vector3 accVal;
    public float time = 0;
    float milli;
    float second;
    string printTime;

    public Text txtGyro;
    public Text txtTime;
    public Text txtTouch;
    public Text txtAcc;
    public Text txtSitUp;
    public Text txtTrueFalse;

    //private List<float> gyroXlist;

    private bool isMoving = false;
    float gyroX;
    int countMotion = 0;
    int countSitUp = 0;
    bool lastIsMoving = false;
    public double max = 3.0;
    public double min = -3.0;

    // Use this for initialization
    void Start () {
        Input.gyro.enabled = true;
        //txtGyro = this.gameObject.GetComponent<Text>();
        // returns a quaternion Input.gyro.attitude
        // returns a vector3 Input.gyro.rotationRate

        txtTouch.text = "haha";

        //InvokeRepeating("calcSitup", 0, 0.5f);
        // Invoke(calcSitup, 0.5)
    }
	
	// Update is called once per frame
	void Update () {
        //lol();
	}

    void FixedUpdate(){
        //printTime = string.Format("{0},{1}", System.DateTime.Now.Second, System.DateTime.Now.Millisecond);
        //txtTime.text = printTime;
        gyroVal = Input.gyro.rotationRate;
        gyroX = gyroVal.x;
        calcSitup();
        txtGyro.text = gyroVal.ToString();
        //print(gyroVal.ToString());
        

        //acc();

    }


    public int count = 0;
    void lol()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                count += 1;
                txtTouch.text = count.ToString();
            }
        }
    }

    void acc()
    {
        string s;

        accVal = Input.acceleration;
        //Vector3 dab = new Vector3(accVal.x, accVal.y, accVal.z);
        s = string.Format("({0}, {1}, {2})", accVal.x, accVal.y, accVal.z);
        txtAcc.text = s;
        //print(s);
    }


    //invoke repeating this function
    //jk dont^^
    //situp world record: 87 in 1min, 3 every 2 sec
    void calcSitup()
    {
        //gyroVal = Input.gyro.rotationRate;
        gyroX = gyroVal.x;
        //gyroXlist.Add(gyroX);

        if(gyroX <= max && gyroX >= min /*&& lastIsMoving == true*/) //around 0 range
        {

            isMoving = false;
            txtTrueFalse.text = string.Format("{0}, {1}", isMoving, countMotion);
            lastIsMoving = false;

        }
        else if((gyroX > max || gyroX < min) && lastIsMoving == false) //out of 0 range
        {

            isMoving = true;
            lastIsMoving = true;
            countMotion += 1;
            txtTrueFalse.text = string.Format("{0}, {1}", isMoving, countMotion);

        }

        if (isMoving == false && countMotion == 2)
        {
            countSitUp += 1;
            txtSitUp.text = countSitUp.ToString();
            countMotion = 0; //reset motion count back to 0 to begin detecting th enext situp
            
        }
    }
}
