using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarUI : MonoBehaviour {

    public float spaceBarReset = 0.75f;
    public bool spaceBarFall = false;
    private Vector3 ogPos;

    // Use this for initialization
    void Start () {
        ogPos = this.transform.localPosition;	
	}
	
	// Update is called once per frame
	void Update () {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Space")
            {
                print("ON HOVER");
                spaceBarFall = true;
                spaceBarReset = 0.75f;
            }

        }

        if (spaceBarFall == true)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - Time.unscaledDeltaTime * 2.5f, this.transform.localPosition.z);

            spaceBarReset -= Time.unscaledDeltaTime;
            if (spaceBarReset <= 0)
            {
                spaceBarReset = 0.75f;
                spaceBarFall = false;

                this.transform.localPosition =ogPos;
            }
        }

    }

    public void ResetUI()
    {
        spaceBarFall = false;
        this.transform.localPosition = ogPos;
    }
}
