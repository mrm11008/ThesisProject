using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    private float time = 5f;
    private float timer = 6.5f;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        var temp = this.GetComponent<Renderer>().material.color;
        temp.a -= Time.deltaTime / time;

        this.GetComponent<Renderer>().material.color = temp;
        timer -= Time.deltaTime;
        if (timer <= 1.5f)
        {
            Destroy(this.gameObject);
        }
    }


}
