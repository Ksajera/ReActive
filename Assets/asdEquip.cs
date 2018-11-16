using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdEquip : MonoBehaviour {


	// Use this for initialization
	void Start () {
        print("woke");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("clicked");
            transform.parent.gameObject.GetComponent<ChangingEquip>().onClickEquipthis();
            print("clocked");
        }
    }
}
