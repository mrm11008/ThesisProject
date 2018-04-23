using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
    private Vector3 rotate;

    public float speed = 25f;
	// Use this for initialization
	void Start () {
        rotate = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotate * Time.deltaTime * speed);
	}
}
