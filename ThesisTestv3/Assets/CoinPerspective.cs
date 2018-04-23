using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPerspective : MonoBehaviour {

    public Vector3 originalPosition;
    private Vector3 cleanOriginalPosition;

    private Vector3 cameraDirection;
    public Rotate camera;
	// Use this for initialization
	void Start () {
        camera = FindObjectOfType<Rotate>();

        originalPosition = this.transform.position;
        cleanOriginalPosition = this.transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        cameraDirection = camera.transform.forward;

        if (((Vector3.Dot(cameraDirection, Vector3.up) > 0.9f) && (Vector3.Dot(cameraDirection, Vector3.up) < 1.1f) && camera.turning == false))
        {
            Vector3 temp = transform.position;

            temp.y = 1.5f;
            // temp.y = 2.25f;
            /*
            if (sideWays == true)
            {
                
            }
            else
            {
                temp.y = 0f;
            }
            if (tilted == true)
            {
                temp.y = 1.15f;
            }
            else if (sideWays == false)
            {
                temp.y = 0f;
            }
            */
            transform.position = temp;
            
        }
        else if (((Vector3.Dot(cameraDirection, -Vector3.up) > 0.9f) && (Vector3.Dot(cameraDirection, -Vector3.up) < 1.1f)) && camera.turning == false)
        {
            Vector3 temp = transform.position;
            temp.y = 1.5f;
            /*
            if (sideWays == true)
            {
                temp.y = 0.5f;
            }
            else
            {
                temp.y = 0f;
            }
            if (tilted == true)
            {
                temp.y = 1.15f;
            }
            else if (sideWays == false)
            {
                temp.y = 0f;
            }
            */
            transform.position = temp;
        }
        else
        {
            Vector3 temp = transform.position;
            temp.y = originalPosition.y;
            transform.position = temp;
        }

        if (((Vector3.Dot(cameraDirection, Vector3.forward) > 0.9f) && (Vector3.Dot(cameraDirection, Vector3.forward) < 1.1f) && camera.turning == false))
        {
            Vector3 temp = transform.position;
            temp.z = 0f;
            transform.position = temp;
        }
        else if (((Vector3.Dot(cameraDirection, -Vector3.forward) > 0.9f) && (Vector3.Dot(cameraDirection, -Vector3.forward) < 1.1f)) && camera.turning == false)
        {
            Vector3 temp = transform.position;
            temp.z = 0f;
            transform.position = temp;
        }
        else
        {

            Vector3 temp = transform.position;
            temp.z = originalPosition.z;
            transform.position = temp;
        }

        if (((Vector3.Dot(cameraDirection, Vector3.right) > 0.9f) && (Vector3.Dot(cameraDirection, Vector3.right) < 1.1f)) && camera.turning == false)
        {
            Vector3 temp = transform.position;
            //temp.y = 1.75f;
            temp.x = 0f;
            /*
            if (tilted == true)
            {
                temp.x = -1.05f;
            }
            else
            {
                temp.x = 0f;
            }
            */
            transform.position = temp;
        }
        else if (((Vector3.Dot(cameraDirection, -Vector3.right) > 0.9f) && (Vector3.Dot(cameraDirection, -Vector3.right) < 1.1f)) && camera.turning == false)
        {
            Vector3 temp = transform.position;
            temp.x = 0f;
            //temp.y = 1.75f;
            //temp.x = 0f;
            /*
            if (tilted == true)
            {
                temp.x = -1.05f;
            }
            else
            {
                
            }
            */
            transform.position = temp;

        }
        else
        {
            Vector3 temp = transform.position;
            temp.x = originalPosition.x;
            transform.position = temp;
        }
        
    }
}
