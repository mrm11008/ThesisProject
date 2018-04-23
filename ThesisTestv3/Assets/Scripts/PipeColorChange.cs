using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeColorChange : MonoBehaviour {

    public Material m;

	// Use this for initialization
	void Start () {
        m.SetColor("Color",Color.red);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
