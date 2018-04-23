using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScreenRotate : MonoBehaviour {

    public Vector3 rotate;
    public bool spin = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (spin == true)
        {
            //transform.Rotate(rotate * Time.deltaTime * 50);

        }
    }

    private void OnMouseOver()
    {
        transform.Rotate(rotate * Time.deltaTime * 50);
    }
}
