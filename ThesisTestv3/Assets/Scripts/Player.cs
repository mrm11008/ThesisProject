using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public bool onRotatingPlatform {get; set;}

	public Transform Parent;
	public Vector3 difference;
	public Fall fall;

	public Perspective currentPlatform;

	public Rotate camera;

    public Vector3 cameraDirection;

    public GameObject deathParticles;
    public GameObject deathParticlesv2;
    public GameObject deathParticlesv3;

    public GameObject coinParticles;
    public GameObject coinParticlesv2;

    public Animator robot;
    private bool playAnim = true;
    private float animWaitTime = 0f;
    // int idleState = Animator.StringToHash("Robot_Idle");
    // Use this for initialization
    
    void Start () {
		fall = this.GetComponent<Fall> ();
	}
	
	// Update is called once per frame
	void Update () {

        if (ScriptManager.instance.isPlaying() == true)
        {
            robot.SetBool("talking",true);
        } else
        {
            robot.SetBool("talking", false);

            if (playAnim == false)
            {
                animWaitTime = Random.Range(3f, 10f);
                playAnim = true;

            }
            else
            {
                animWaitTime -= Time.deltaTime;
                if (animWaitTime <= 0)
                {
                    RandomAnimation();
                }
            }
        }


        
		if (Parent != null) {
			//difference = Parent.transform.position + transform.position;
			//transform.position = Parent.transform.position + difference;

            if (this.GetComponent<Fall>().falling == false)
            {
                cameraDirection = camera.transform.forward;



                
            }

            //fakeChild.transform.position = Parent.transform.position;
           // this.transform.parent = fakeChild.transform;
            this.transform.parent = Parent.transform;

        } else {
			this.transform.parent = null;
		}
		if (this.transform.parent != null) {
			//this.transform.rotation = this.transform.parent.rotation;
		}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //RandomAnimation();
        }
	}



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "death")
        {
            //GM.instance.GameOver();
            
            //DeathParticles();
            //Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Spikes")
        {
            GM.instance.GameOver();
            
            DeathParticles();
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter(Collider other){

		if (other.tag == "Coin") {
			GM.instance.CoinSound ();
            
			Destroy (other.gameObject);
			GM.instance.IncrementCoins ();
            CoinParticles(other.transform.position);

            if (fall.moving == false)
            {
                ScriptManager.instance.CoinCollectUttererance();
            }
        }

		if (other.tag == "PressurePlate") {
			onRotatingPlatform = true;
			this.transform.parent = other.transform;
			//Try and implement a "STICK" functionality
			//other.gameObject.GetComponent<RotatePlatform> ().Rotate();
		}

		if (other.tag == "GravityShift" && camera.turning == false) {
            
            
			if (camera.turning == false && fall.gravityShift == false) {
                
                fall.gravityShift = true;
                Destroy(other.gameObject);


            } else  if (camera.turning == false && fall.gravityShift == true)
            {
                
                //fall.gravityShift = false;
                
                //this.GetComponent<GravityNew> ().gravityShift = false;
            }
		}
		if (other.tag == "MovingPlatform" || other.tag == "PerspectiveBlock" || other.tag == "WinBlock") {
			//this.transform.parent = other.gameObject.transform;
			//fakeChild.transform.position = other.gameObject.transform.position;

			if (camera.turning == false) {
				currentPlatform = other.transform.gameObject.GetComponentInParent<Perspective>();
				this.GetComponent<Fall> ().currentPlatform = currentPlatform;
				//Parent = other.gameObject.transform;
			}


		}




    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "WinBlock" && fall.moving == false)
        {
           // ScriptManager.instance.LevelCompleteUtterance();
            currentPlatform = other.transform.gameObject.GetComponentInParent<Perspective>();
            this.GetComponent<Fall>().currentPlatform = currentPlatform;

            GM.instance.Win();
        }
        
    }


    void OnTriggerExit(Collider other){
		if (other.tag == "PressurePlate") {
			onRotatingPlatform = false;
			this.transform.parent = null;

		}

		if ((other.tag == "MovingPlatform" || other.tag == "PerspectiveBlock")) {
			//this.transform.parent = null;

			if (camera.turning == false) {
				//currentPlatform = null;
				//Parent = null;
			}

		}
	}

    public void DeathParticles()
    {
        var amount = 5;
        for (int i = 0; i < amount; i++)
        {
            //your code here
            var d = Instantiate(deathParticles, transform.position, Quaternion.identity);
            var s = Random.Range(0.1f, 0.3f);
            var v = new Vector3(s, s, s);
            d.transform.localScale = v;
            d.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere.normalized * Random.Range(5,40f));
            


        }
        var amountv2 = 36;
        for (int i = 0; i < amountv2; i++)
        {
            var d = Instantiate(deathParticlesv2, transform.position, Quaternion.identity);
            d.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere.normalized * Random.Range(2.5f, 20f));
        }

        var amountv3 = 24;
        for (int i = 0; i < amountv3; i++)
        {
            var c = Instantiate(deathParticlesv3, transform.position, Quaternion.identity);
            //Vector3 v2 = new Vector3(Random.Range(0, 0.75f), Random.Range(0, 0.75f), Random.Range(0, 0.75f));
            c.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere.normalized * Random.Range(7, 50f));
        }
    }

    public void CoinParticles(Vector3 pos)
    {
        var amount = 4;
        for (int i = 0; i < amount; i++)
        {
            //your code here
            var d = Instantiate(coinParticles, pos, Quaternion.identity);
            //Vector3 v = new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            d.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere.normalized * Random.Range(5, 20f));


        }
        var amountv2 = 7;
        for (int i = 0; i < amountv2;i++)
        {
            var c = Instantiate(coinParticlesv2, pos, Quaternion.identity);
            //Vector3 v2 = new Vector3(Random.Range(0, 0.75f), Random.Range(0, 0.75f), Random.Range(0, 0.75f));
            c.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere.normalized * Random.Range(2.5f, 10f));
        }



    }

    public void RandomAnimation()
    {
        int randomNumber = Random.Range(1, 7);
        print("anim");

        robot.SetTrigger("idle" + randomNumber);
        playAnim = false;
    }


}
