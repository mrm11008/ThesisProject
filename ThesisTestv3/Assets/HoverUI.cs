using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverUI : MonoBehaviour {


    public enum ButtonType {Start, Controls, LevelSelect, Back, MainMenu, Next, Restart,Resume,ControlsInGame,DeathReset, None, Quit};
    public ButtonType thisButtonType;

    public Material hoverMaterial;
    public Material defaultMaterial;
    private bool hovering = false;

    public GameObject saved;

    public Camera cameraUI;

    private Ray rays;

    public bool controlScreenUI = false;

    public LayerMask mask;

    public bool playHoverSound = true;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update () {
        // var ray = rays;

        var ray = cameraUI.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, mask))
        {
            if (hit.transform.tag == "Space" || hit.transform.tag == "Key")
            {
                //print("ON HOVER");
                saved = hit.transform.gameObject;

                    if ((hit.transform == this.transform.parent || hit.transform == this.transform.parent.parent))
                    {
                        this.GetComponent<MeshRenderer>().material = hoverMaterial;
                        hovering = true;
                    }
                    else
                    {
                    //this.GetComponent<MeshRenderer>().material = defaultMaterial;
                    if (hit.transform.gameObject == this.transform.gameObject)
                    {
                        this.GetComponent<MeshRenderer>().material = hoverMaterial;
                        hovering = true;


                    }
                    else
                    {
                        this.GetComponent<MeshRenderer>().material = defaultMaterial;
                        hovering = false;


                    }
                }


            }
            else
            {
                this.GetComponent<MeshRenderer>().material = defaultMaterial;
                hovering = false;


            }

        } else
        {
            this.GetComponent<MeshRenderer>().material = defaultMaterial;
            hovering = false;


        }
        if (saved != null)
        {
            if (this.transform.parent != null && saved.transform != this.transform.parent.parent)
            {

                if (saved.transform == this.transform.parent || saved.transform == this.transform.parent.parent)
                {
                }
                else
                {
                    //this.GetComponent<MeshRenderer>().material = defaultMaterial;

                }
            }
            else
            {
                

            }

        }
        else
        {
            saved = null;
        }


        if (hovering == true)
        {
            if (playHoverSound == true)
            {
                Manager.instance.UIHoverSound();
                playHoverSound = false;
            }
            //this.transform.parent.localScale = new Vector3(2,2,2);
        } else
        {
            playHoverSound = true;
            //this.transform.parent.localScale = new Vector3(1, 1, 1);

        }

    }



    private void OnMouseDown()
    {
        if (thisButtonType == ButtonType.Start)
        {
            //MetricsLogger.Instance.LoadNextScene();
            TitleManager.instance.StartGameHappy();
            Manager.instance.UIClickSound();
        }
        if (thisButtonType == ButtonType.Resume)
        {
            GM.instance.Resume();
            Manager.instance.UIClickSound();

        }
        if (thisButtonType == ButtonType.ControlsInGame)
        {
            GM.instance.ControlsScreen();
            Manager.instance.UIClickSound();

        }
        if (thisButtonType == ButtonType.Restart)
        {
            GM.instance.RestartLevel();
            Manager.instance.UIClickSound();

        }
        if (thisButtonType == ButtonType.DeathReset)
        {
            GM.instance.DeathReset();
            Manager.instance.UIClickSound();

        }

        if (thisButtonType == ButtonType.Controls)
        {
            TitleManager.instance.ControlScreen();
            Manager.instance.UIClickSound();

        }
        if (thisButtonType == ButtonType.Back)
        {
            TitleManager.instance.TitleScreen();
            Manager.instance.UIClickSound();

        }
        if (thisButtonType == ButtonType.Next)
        {
            GM.instance.NextLevel();
            Manager.instance.UIClickSound();

        }
        if (thisButtonType == ButtonType.MainMenu)
        {
            GM.instance.MainMenu();
            Manager.instance.UIClickSound();

        }

        if (thisButtonType == ButtonType.Quit)
        {
            Application.Quit();
        }
    }
}
