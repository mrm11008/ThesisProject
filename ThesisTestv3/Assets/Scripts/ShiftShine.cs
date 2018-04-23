using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftShine : MonoBehaviour {

    public Renderer rend;
    public float shineTimer = 0.25f;
    public bool flash = false;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        //rend.material.shader = Shader.Find("Glow");
	}

    private void FixedUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flash = true;
        }
        if (flash == true)
        {
            float shine = Mathf.PingPong(Time.time, 5.0f);
            float l = Mathf.Lerp(1f, 0.5f, 0.25f);
            rend.material.SetFloat("_Glow", l);
            shineTimer -= Time.deltaTime;
            if (shineTimer <= 0)
            {
                flash = false;
            }
        } else if (flash == false)
        {
            float l = Mathf.Lerp(0.5f, 1f, 0.25f);
            rend.material.SetFloat("_Glow", l);
            shineTimer = 0.25f;
        }
    }
}
