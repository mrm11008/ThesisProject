﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpin : MonoBehaviour {
    public Vector3 rotate;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotate * Time.unscaledDeltaTime * 75);

    }
}
