using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iris : MonoBehaviour {

    public GameObject tlEye;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var s = tlEye.transform.localScale;
        print(transform.position);
        print(tlEye.transform.localScale);
        s.z = s.z + Mathf.Abs(this.transform.position.x);

        tlEye.transform.localScale = s;
        print(tlEye.transform.localScale);
    }
}
