using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarUI : MonoBehaviour {

    public float spaceBarReset = 0.75f;
    public bool spaceBarFall = false;
    private Vector3 ogPos;

    public GameObject spaceBarArrows;


    // Use this for initialization
    void Start () {
        ogPos = spaceBarArrows.transform.localPosition;	
	}
	
	// Update is called once per frame
	void Update () {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Space")
            {
                //print("ON HOVER");
                spaceBarFall = true;
                spaceBarReset = 0.75f;
            } else
            {
                spaceBarFall = false;

            }

        } else
        {
            spaceBarFall = false;

        }

        if (spaceBarFall == true)
        {
            spaceBarArrows.transform.localPosition = new Vector3(spaceBarArrows.transform.localPosition.x, Mathf.PingPong(Time.unscaledTime / 2, 0.2f), spaceBarArrows.transform.localPosition.z);

            /*
            spaceBarArrows.transform.localPosition = new Vector3(spaceBarArrows.transform.localPosition.x, spaceBarArrows.transform.localPosition.y - Time.unscaledDeltaTime * 2.5f, spaceBarArrows.transform.localPosition.z);

            spaceBarReset -= Time.unscaledDeltaTime;
            if (spaceBarReset <= 0)
            {
                spaceBarReset = 0.75f;
                spaceBarFall = false;

                spaceBarArrows.transform.localPosition =ogPos;
            }
            */
        }

    }

    public void ResetUI()
    {
        spaceBarFall = false;
        this.transform.localPosition = ogPos;
    }
}
