using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour {

	public bool rotating = false;

    public Vector3 rotationDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Rotate(Vector3 rotationAngle) {
        //StartCoroutine (Rotation(this.transform.parent.transform, new Vector3(0,0,90), 1.5f));
        //StartCoroutine(Rotation(this.transform.transform, rotationAngle, 0.25f));
    }

	public IEnumerator Rotation(Transform thisTransform, Vector3 degrees, float time) {
		print ("Rotate called");
		rotating = true;
		Quaternion startRotation = thisTransform.rotation;
		Quaternion endRotation = thisTransform.rotation * Quaternion.Euler (degrees);
		float rate = 1.0f / time;
		float t = 0.0f;
		while (t < 1.0f) {
			t += Time.deltaTime * rate;
			thisTransform.rotation = Quaternion.Slerp (startRotation, endRotation, t);
			yield return null;
		}
		rotating = false;
	}
}
