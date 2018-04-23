using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour {
    public Camera cam;


    public bool q = false;
    public bool e = false;

    public Quaternion rot;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.rotation = Quaternion.LookRotation(-this.cam.transform.up);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {

            this.transform.rotation = Quaternion.LookRotation(this.cam.transform.up);
            //this.transform.rotation = Quaternion.Euler(-this.transform.parent.forward);
            rot = Quaternion.LookRotation(this.cam.transform.up);
        }

        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)))
        {
            this.transform.rotation = Quaternion.LookRotation(-this.cam.transform.up);
            rot = Quaternion.LookRotation(-this.cam.transform.up);
        }


        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)))
        {
            this.transform.rotation = Quaternion.LookRotation(this.cam.transform.right);
            rot = Quaternion.LookRotation(this.cam.transform.right);

        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)))
        {
            this.transform.rotation = Quaternion.LookRotation(-this.cam.transform.right);
            rot = Quaternion.LookRotation(-this.cam.transform.right);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            q = true;
            //rot = Quaternion.LookRotation(this.cam.transform.up - this.cam.transform.right);
            //this.transform.rotation = Quaternion.LookRotation(-this.cam.transform.up + this.cam.transform.right);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            e = true;
            //rot = Quaternion.LookRotation(this.cam.transform.up - this.cam.transform.right);
            //this.transform.rotation = Quaternion.LookRotation(this.cam.transform.up + this.cam.transform.right);

        }
        this.transform.rotation = rot;
 
        if (q == true || e == true)
        {
            //this.transform.rotation = rot;
        }
    }
}
