using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkTalking : MonoBehaviour {

    private Renderer r;

    private Vector3 ogScale;
    private Color ogColor;
	// Use this for initialization
	void Start () {
        r = this.GetComponent<Renderer>();
        ogScale = this.transform.localScale;
        ogColor = r.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (ScriptManager.instance.isPlaying() == true)
        {
            //emission
            float floor = 1.0f;
            float ceiling = 3.0f;
            //print("changing");
            Material mat = r.material;
            float emission = floor + Mathf.PingPong(Time.time, ceiling - floor);
            //print(emission);
            Color baseColor = Color.yellow;
            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
            mat.SetColor("_EmissionColor", finalColor);


            //scale
            float sFloor = 0.2f;
            float sCeiling = 0.6f;
            Vector3 scale = this.transform.localScale;
            scale = new Vector3(sFloor + Mathf.PingPong(Time.time*5, sCeiling - sFloor), sFloor + Mathf.PingPong(Time.time*6, sCeiling - sFloor), sFloor + Mathf.PingPong(Time.time*5, sCeiling - sFloor));
            this.transform.localScale = scale;
        } else
        {
            
            //this.transform.localScale = ogScale;
            this.transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, ogScale.x,0.1f), Mathf.Lerp(transform.localScale.y, ogScale.y, 0.1f), Mathf.Lerp(transform.localScale.z, ogScale.z, 0.1f));
            r.material.SetColor("_EmissionColor", ogColor);
        }
	}
}
