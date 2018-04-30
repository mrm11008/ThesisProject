using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScreenRotate : MonoBehaviour {

    public Vector3 rotate;
    private Quaternion ogRot;
    public bool spin = false;
	// Use this for initialization
	void Start () {

        ogRot = this.transform.rotation;
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

        transform.Rotate(rotate * Time.unscaledDeltaTime * 125);
    }
    void OnMouseExit()
    {
        transform.rotation = ogRot;
    }

    public void ResetUI()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
