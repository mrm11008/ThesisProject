using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFlicker : MonoBehaviour {

    private MeshRenderer rend;
    private float textureOffset = 0;

    // Use this for initialization
    void Start () {
        rend = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        textureOffset -= Time.deltaTime * 10f;
        if (textureOffset < -10f)
        {
            textureOffset += 10f;
        }
        rend.material.SetTextureOffset("_MainTex", new Vector2(textureOffset, textureOffset));
	}
}
