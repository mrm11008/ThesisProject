using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public GameObject titleScreen;
    public GameObject levelSelect;
    public GameObject controlScreen;

    public GameObject title;

    public bool miniTitle = false;
    public Vector3 titlePos;
    public Vector3 miniTitlePos;
    public Vector3 bigTitlePos;

    private float timeToReachTarget = 0.5f;
    private float t = 0;

    public ControlScreenRotate wSpin;
    public ControlScreenRotate aSpin;
    public ControlScreenRotate sSpin;
    public ControlScreenRotate dSpin;
    public ControlScreenRotate qSpin;
    public ControlScreenRotate eSpin;



    // Use this for initialization
    void Start () {
        titlePos = title.transform.position;
        bigTitlePos = title.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		if (miniTitle == false)
        {
            t += Time.deltaTime / timeToReachTarget;
            title.transform.position = Vector3.Lerp(titlePos, bigTitlePos, t);
        } else
        {
            t += Time.deltaTime / timeToReachTarget;
            title.transform.position = Vector3.Lerp(titlePos, miniTitlePos, t);

        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "W")
            {
                print("ON HOVER");
                hit.transform.gameObject.GetComponent<ControlScreenRotate>().spin = true;                
            }
            
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        if (GM.instance != null && ScriptManager.instance != null)
        {
            if (ScriptManager.instance.angryChar == true)
            {
                ScriptManager.instance.PlayScript("intro", "angry");

            } else
            {
                ScriptManager.instance.PlayScript("intro", "happy");

            }
        }
    }

    public void TitleScreen()
    {
        //title.SetActive(true);
        miniTitle = false;
        titlePos = title.transform.position;
        t = 0;
        titleScreen.SetActive(true);
        levelSelect.SetActive(false);
        controlScreen.SetActive(false);
    }
    public void ControlScreen()
    {
        //title.SetActive(false);
        miniTitle = true;
        titlePos = title.transform.position;
        t = 0;
        titleScreen.SetActive(false);
        levelSelect.SetActive(false);
        controlScreen.SetActive(true);
    }
    public void LevelSelect()
    {
        //title.SetActive(false);
        miniTitle = true;
        titlePos = title.transform.position;
        t = 0;
        titleScreen.SetActive(false);
        levelSelect.SetActive(true);
        controlScreen.SetActive(false);
    }

    private void OnMouseOver()
    {
        if (gameObject.name == "W")
        {
            wSpin.spin = true;
        }
    }

}
