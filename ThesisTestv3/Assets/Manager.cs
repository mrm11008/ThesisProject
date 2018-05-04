using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {



    public static Manager instance = null;

    public bool angryChar = false;


    private AudioSource audso;
    public AudioClip uiHover;
    public AudioClip uiClick;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);


    }

    // Use this for initialization
    void Start () {
        audso = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UIHoverSound()
    {
        audso.PlayOneShot(uiHover);
    }

    public void UIClickSound()
    {
        audso.PlayOneShot(uiClick);
    }


}
