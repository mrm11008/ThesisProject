using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {


	public Transform rotateTo;

	public GameObject player;
	public bool contact = true;

	public float waitTime = 1.1f;

	public bool turning = false;

	public float rotateTime = 0.25f;
    public float rotateSidewaysTime = 0.25f;

    public bool onRotatingPlatform = false;

	public GameObject camera;

    public bool playerMoving = false;

    public GameObject goodbounds;
    public GameObject badbounds;

    public GameObject windForce;

    public Vector3 particleDirection;
	// Use this for initialization
	void Start () {
        //windForce = this.GetComponentInChildren<Stick>().gameObject;

    }
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            playerMoving = player.GetComponent<Fall>().moving;
            onRotatingPlatform = player.GetComponent<Player>().onRotatingPlatform;
        }
        //contact = player.GetComponent<Gravity> ().contact;
        
		Debug.DrawRay (camera.transform.position, camera.transform.forward * 3, Color.green);

		Debug.DrawRay (camera.transform.position, camera.transform.up * 3, Color.blue);

		Debug.DrawRay (transform.position, transform.right * 0.6f, Color.red);



        if (turning == true)
        {
            //goodbounds.SetActive(false);
            //badbounds.SetActive(true);
            //windForce.SetActive(true);
        } else
        {
            //windForce.SetActive(false);
            //badbounds.SetActive(false);
            // goodbounds.SetActive(true);

        }


	}

	void FixedUpdate() {

	}

	void LateUpdate() {
		var fromAngle = transform.rotation;
		//var toAngle = Quaternion.Euler (transform.eulerAngles + new Vector3 (90f, 0f, 0f));

        if (GM.instance != null)
        {
            if ((GM.instance.winScreen.activeSelf == false && GM.instance.gameOverScreen.activeSelf == false) && GM.instance.levelComplete == false)
            {
                if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && turning == false && onRotatingPlatform == false && playerMoving == false)
                {
                    ScriptManager.instance.IncrementWCount();
                    ScriptManager.instance.NotQORECount();

                    StartCoroutine(Rotation(this.transform, new Vector3(90, 0, 0), rotateTime));
                    GM.instance.IncrementRotations();

                }

                if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && turning == false && onRotatingPlatform == false && playerMoving == false)
                {
                    ScriptManager.instance.IncrementSCount();
                    ScriptManager.instance.NotQORECount();

                    StartCoroutine(Rotation(this.transform, new Vector3(-90, 0, 0), rotateTime));
                    GM.instance.IncrementRotations();

                }


                if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && turning == false && onRotatingPlatform == false && playerMoving == false)
                {
                    ScriptManager.instance.IncrementDCount();
                    ScriptManager.instance.NotQORECount();

                    StartCoroutine(Rotation(this.transform, new Vector3(0, -90, 0), rotateTime));
                    GM.instance.IncrementRotations();


                }

                if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && turning == false && onRotatingPlatform == false && playerMoving == false)
                {

                    ScriptManager.instance.IncrementACount();
                    ScriptManager.instance.NotQORECount();

                    StartCoroutine(Rotation(this.transform, new Vector3(0, 90, 0), rotateTime));
                    GM.instance.IncrementRotations();

                }
                if (Input.GetKeyDown(KeyCode.Q) && turning == false && onRotatingPlatform == false && playerMoving == false)
                {
                    ScriptManager.instance.IncrementQCount();
                    ScriptManager.instance.ResetQECount();

                    StartCoroutine(Rotation(this.transform, new Vector3(0, 0, -90), rotateSidewaysTime));
                    GM.instance.IncrementRotations();

                }
                if (Input.GetKeyDown(KeyCode.E) && turning == false && onRotatingPlatform == false && playerMoving == false)
                {
                    ScriptManager.instance.IncrementECount();
                    ScriptManager.instance.ResetQECount();
                    StartCoroutine(Rotation(this.transform, new Vector3(0, 0, 90), rotateSidewaysTime));
                    GM.instance.IncrementRotations();

                }
            }
        }


    }






	public IEnumerator Rotation(Transform thisTransform, Vector3 degrees, float time) {
        ScriptManager.instance.IncrementRotationsBeforeFall();
        //ScriptManager.instance.RotationsUtterance();
		GM.instance.TurnSound ();
		//print ("Rotate called");
		turning = true;
        particleDirection = degrees;
		Quaternion startRotation = thisTransform.rotation;
		Quaternion endRotation = thisTransform.rotation * Quaternion.Euler (degrees);
		float rate = 1.0f / time;
		float t = 0.0f;
        //Camera.main.orthographic = false;
		while (t < 1.0f) {
			t += Time.deltaTime * rate;
			thisTransform.rotation = Quaternion.Slerp (startRotation, endRotation, Mathf.SmoothStep(0.0f, 1f, t));
			yield return null;
		}
        //Camera.main.orthographic = true;
        turning = false;
	}
}
