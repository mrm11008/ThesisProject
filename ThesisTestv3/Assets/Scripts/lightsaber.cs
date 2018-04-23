using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsaber : MonoBehaviour {

    LineRenderer lineRend;
    public Transform startPos;
    public Transform endPos;

    private float textureOffset = 0;
    //private bool on = true;
    //private Vector3 endPosExtendedPos;



	// Use this for initialization
	void Start () {
        lineRend = this.GetComponent<LineRenderer>();
        //endPosExtendedPos = endPos.localPosition;

    }
	
	// Update is called once per frame
	void LateUpdate () {

        var y = endPos.localPosition.y;

        y = Mathf.PingPong(Time.time, 0.01f);
        endPos.localPosition = new Vector3(0,y,0);

        lineRend.SetPosition(0, startPos.position);
        lineRend.SetPosition(1, endPos.position);

        textureOffset -= Time.deltaTime * 10f;
        if (textureOffset < -10f)
        {
            textureOffset += 10f;
        }
        lineRend.sharedMaterials[1].SetTextureOffset("_MainTex", new Vector2(textureOffset, 0));
	}
}
