using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public static TitleManager instance = null;


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


    public GameObject controlsObjects;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);


    }
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



    }

    public void StartGameHappy()
    {
        Manager.instance.angryChar = false;

        SceneManager.LoadScene(1);
        
        if (GM.instance != null && ScriptManager.instance != null)
        {
            if (Manager.instance.angryChar == true)
            {
                ScriptManager.instance.PlayScript("intro", "angry");

            } else
            {
                ScriptManager.instance.PlayScript("intro", "happy");

            }
        }
    }
    public void StartGameAngry()
    {
        Manager.instance.angryChar = true;
        SceneManager.LoadScene(1);

        if (GM.instance != null && ScriptManager.instance != null)
        {
            if (Manager.instance.angryChar == true)
            {
                ScriptManager.instance.PlayScript("intro", "angry");

            }
            else
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
        controlsObjects.SetActive(false);

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
        controlsObjects.SetActive(true);
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
        controlsObjects.SetActive(false);

    }


}
