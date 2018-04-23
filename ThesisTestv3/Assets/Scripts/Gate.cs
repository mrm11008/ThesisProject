using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Open() {
		StartCoroutine(GateControl(this.transform, new Vector3 (0, -1.3f, 0), 1f));
	}

	public void Close() {
		StartCoroutine(GateControl(this.transform, new Vector3 (0, 1.3f, 0), 1f));
	}

	public IEnumerator GateControl(Transform thisTransform, Vector3 distance, float time) {
		print ("Rotate called");

		Vector3 startPosition = thisTransform.position;
		Vector3 endPosition = this.transform.position + distance;
		float rate = 1.0f / time;
		float t = 0.0f;
		while (t < 1.0f) {
			t += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp (startPosition, endPosition, t);
			yield return null;
		}

	}
}
