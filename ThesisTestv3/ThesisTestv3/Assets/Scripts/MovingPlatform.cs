using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public GameObject camera;

	public Vector3 fallDirection;

	public bool gravityDisabled = true;
	public bool contact = false;

	public bool moving = false;

	public Vector3 positiveMoveVector;
	public Vector3 negativeMoveVector;
	public float moveTime;

	public bool positiveMove = false;
	public bool negativeMove = false;

	public Perspective platformPerspective;
	public GravityNew playerGravity;
	public bool shift = false;

	public bool fallUp = false;
	public bool fallDown = false;
	public bool fallLeft = false;
	public bool fallRight = false;
	public bool fallForward = false;
	public bool fallBack = false;

	// Use this for initialization
	void Start () {
		playerGravity = GameObject.FindGameObjectWithTag("Player").GetComponent<GravityNew>();
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawRay (camera.transform.position, -camera.transform.up * 10, Color.green);
		Debug.DrawRay (transform.position, transform.forward * 3, Color.green);

		Debug.DrawRay (transform.position, transform.up * 3, Color.blue);

		Debug.DrawRay (transform.position, transform.right * 0.6f, Color.red);



		if (playerGravity.gravityShift == true && shift == false) {
		//	positiveMoveVector = -positiveMoveVector;
		//	negativeMoveVector = -negativeMoveVector;
		//	positiveMove = !positiveMove;
		//	negativeMove = !negativeMove;
		//	shift = true;
				positiveMoveVector = positiveMoveVector;
				negativeMoveVector = negativeMoveVector;
				positiveMove = positiveMove;
				negativeMove = negativeMove;
				shift = true;
		}

		if (fallUp == true) {
			fallDirection = transform.up;
		} else 	if (fallDown == true) {
			fallDirection = -transform.up;
		} else 	if (fallLeft == true) {
			fallDirection = -transform.right;
		}  else 	if (fallRight == true) {
			fallDirection = transform.right;
		}  else 	if (fallForward == true) {
			fallDirection = transform.forward;
		}  else 	if (fallBack == true) {
			fallDirection = -transform.forward;
		}



		if (Input.GetKeyDown (KeyCode.Space)) {
			/*
			if ((Vector3.Dot (-camera.transform.up, -transform.up) > 0.9f) && (Vector3.Dot (-camera.transform.up, -transform.up) < 1.1f) || (Vector3.Dot (-camera.transform.up, transform.up) > 0.9f) && (Vector3.Dot (-fallDirection, transform.up) < 1.1f)) {
				
				fallDirection = camera.transform.up;
				Physics.gravity = (-camera.transform.up).normalized * 100f;
				rb.isKinematic = false;
				gravityDisabled = !gravityDisabled;
			}
*/
			if ((Vector3.Dot (-camera.transform.up, fallDirection) > 0.9f) && (Vector3.Dot (-camera.transform.up, fallDirection) < 1.1f)) {

				if (negativeMove == false) {
					StartCoroutine(MovePlatform (this.transform, negativeMoveVector, moveTime));

				}
				positiveMove = false;
				negativeMove = true;

			} else if ((Vector3.Dot (-camera.transform.up, -fallDirection) > 0.9f) && (Vector3.Dot (-camera.transform.up, -fallDirection) < 1.1f)) {
				

				if (positiveMove == false) {
					StartCoroutine(MovePlatform (this.transform, positiveMoveVector, moveTime));

				}
				negativeMove = false;
				positiveMove = true;
			}
		}
	}
		




	public IEnumerator MovePlatform(Transform thisTransform, Vector3 distance, float time) {
		print ("Rotate called");
		moving = true;
		Vector3 startPosition = thisTransform.position;
		Vector3 endPosition = this.transform.position + distance;
		float rate = 1.0f / time;
		float t = 0.0f;
		while (t < 1.0f) {
			t += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp (startPosition, endPosition, t);
			yield return null;
		}
		//platformPerspective.originalPosition = this.transform.position;
		moving = false;
	}

}
