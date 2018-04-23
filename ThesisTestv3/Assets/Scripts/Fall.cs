using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {

    private Vector3 fallDirection;
    private bool wallHit = false;
    public bool falling = false;
    private Vector3 fallTo;
    public bool moving = false;
    private float moveOffset = 0.65f;
    private GameObject movingWall;
    private Vector3 movingWallOffset;
    public bool movingWallHit;
    private Vector3 fallToMovingWall;
    private Vector3 sparkPoint;
    private GameObject sparkParent;
    private GameObject sparkCheck;

    public bool gravityShift = false;

    public Player player;

    private float i = 0.2f;

    public float rayDistance = 100f;

    public Camera camera;
    private int layermask;
    public bool killAfterFall = false;
    public Perspective currentPlatform;

    public GameObject pX;
    public GameObject pY;
    public GameObject pZ;

    public Vector3 startPositions;
    public GameObject impactSparks;
    public GameObject groundSparks;

    private bool spikeDeath = false;
    private bool wallDeath = false;
    private bool boundryDeath = false;

    private bool platformIsMoving = false;

    // Use this for initialization
    void Start () {
        spikeDeath = false;
        wallDeath = false;
        boundryDeath = false;
        camera = Camera.main;
        layermask = LayerMask.GetMask("Wall", "Ground", "Spikes","Boundry");
        
    }
	
	// Update is called once per frame
	void Update () {

        if (camera.GetComponentInParent<Rotate>().turning == true)
        {
            pX.SetActive(false);
            pY.SetActive(false);
            pZ.SetActive(false);
        }


        //raycast wall checks
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.right, out hit, 0.6f))
        {
            //print("found object:" + hit.collider.gameObject.name);

        }
        if (gravityShift == false)
        {
            fallDirection = -camera.transform.up;
            //rayDistance = -rayDistance;
        }
        else
        {
            fallDirection = camera.transform.up;
            //rayDistance = -rayDistance;
        }

        Debug.DrawRay(transform.position, fallDirection * 20, Color.blue);


        //SIDEWAYS PLATFORM UTTERANCE

        if(currentPlatform.GetComponent<Perspective>().tilted == true && currentPlatform.GetComponent<Perspective>().tilted == true)
        {
            ScriptManager.instance.SidewaysPlatformUtterance();
        }

        if (currentPlatform.GetComponent<MovingPlatform>() != null)
        {

            if (currentPlatform.GetComponent<MovingPlatform>().moving == false)
            {
                platformIsMoving = false;

            }
            else
            {
                platformIsMoving = true;

            }

        } else
        {
            platformIsMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (GM.instance.winScreen.activeSelf == false && GM.instance.gameOverScreen.activeSelf == false) && platformIsMoving == false)
        {


            //fallTo = Vector3.zero;

            //if (currentPlatform.GetComponent<MovingPlatform>() != null)
           /// {
                //changeOP = true;

            //}



            if ((Vector3.Dot(fallDirection, -transform.right) > 0.9f) && (Vector3.Dot(fallDirection, -transform.right) < 1.1f))
            {
                //print("DOT PRODUCT IS THE SAME");
                if (Physics.Raycast(transform.position, -transform.right, out hit, rayDistance, layermask))
                {
                    if (hit.collider.gameObject.tag == "Wall" || hit.collider.gameObject.tag == "death" )
                    {
                        pX.SetActive(true);
                        pY.SetActive(false);
                        pZ.SetActive(false);

                        if (currentPlatform.GetComponent<MovingPlatform>() != null)
                        {
                            //this if is new
                            if (currentPlatform == hit.collider.GetComponentInParent<Perspective>())
                            {
                                movingWall = hit.collider.gameObject;
                                movingWallHit = true;
                                movingWallOffset = new Vector3(moveOffset, 0, 0);
                            }

                        }
                        //player.Parent = hit.collider.gameObject.GetComponent<Perspective>().transform;
                        var v = hit.point;
                        sparkPoint = v;
                        if (hit.collider.gameObject.tag == "death")
                        {
                            v.x = v.x + moveOffset;
                            fallTo = v;
                        } else
                        {
                            var vv = hit.collider.transform.position;
                            vv.x = vv.x + moveOffset;
                            fallTo = vv;
                        }


                        
                        if (hit.transform.GetComponentInParent<Perspective>() != null)
                        {
                            sparkParent = hit.transform.GetComponentInParent<Perspective>().gameObject;

                        }
                        sparkCheck = hit.collider.gameObject;

                        if (hit.collider.gameObject.tag == "Wall")
                        {

                        }

                        //fallTo = v;
                        
                        wallHit = true;
                    }
                    else if (hit.collider.gameObject.tag == "Ground")
                    {
                        pX.SetActive(true);
                        pY.SetActive(false);
                        pZ.SetActive(false);

                        var v = hit.point;
                        var vv = hit.collider.gameObject.GetComponentInParent<Perspective>().transform.position;
                        sparkPoint = v;
                        if (hit.transform.GetComponentInParent<Perspective>() != null)
                        {
                            sparkParent = hit.transform.GetComponentInParent<Perspective>().gameObject;

                        }

                        sparkCheck = hit.collider.gameObject;

                            v.x = v.x + moveOffset;
                            vv.x = vv.x + moveOffset;
                            fallTo = vv;
                        


                        wallHit = true;
                    }
                }
            }
            else if ((Vector3.Dot(fallDirection, transform.right) > 0.9f) && (Vector3.Dot(fallDirection, transform.right) < 1.1f))
            {
                //print(" NEW DOT PRODUCT IS THE SAME");
                if (Physics.Raycast(transform.position, transform.right, out hit, rayDistance, layermask))
                {
                    if (hit.collider.gameObject.tag == "Wall" || hit.collider.gameObject.tag == "death")
                    {

                        pX.SetActive(true);
                        pY.SetActive(false);
                        pZ.SetActive(false);

                        if (currentPlatform.GetComponent<MovingPlatform>() != null)
                        {
                            if (currentPlatform == hit.collider.GetComponentInParent<Perspective>())
                            {
                                movingWall = hit.collider.gameObject;
                                movingWallHit = true;
                                movingWallOffset = new Vector3(-moveOffset, 0, 0);
                            }

                        }
                        //player.Parent = hit.collider.gameObject.GetComponent<Perspective>().transform;
                        var v = hit.point;
                        sparkPoint = v;
                        if (hit.collider.gameObject.tag == "death")
                        {
                            v.x = v.x - moveOffset;
                            fallTo = v;
                        }
                        else
                        {
                            var vv = hit.collider.transform.position;
                            vv.x = vv.x - moveOffset;
                            fallTo = vv;
                        }
                        //var vv = hit.collider.gameObject.GetComponentInParent<Perspective>().transform.position;

                        //v.x = v.x - moveOffset;
                        //vv.x = vv.x - moveOffset;
                        //fallTo = v;
                        if (hit.transform.GetComponentInParent<Perspective>() != null)
                        {
                            sparkParent = hit.transform.GetComponentInParent<Perspective>().gameObject;

                        }
                        sparkCheck = hit.collider.gameObject;

                        if (hit.collider.gameObject.tag == "Wall")

                        {

                        }

                        wallHit = true;

                    }
                    else if (hit.collider.gameObject.tag == "Ground")
                    {
                        pX.SetActive(true);
                        pY.SetActive(false);
                        pZ.SetActive(false);

                        var v = hit.point;
                        sparkPoint = v;
                        var vv = hit.collider.gameObject.GetComponentInParent<Perspective>().transform.position;

                        if (hit.transform.GetComponentInParent<Perspective>() != null)
                        {
                            sparkParent = hit.transform.GetComponentInParent<Perspective>().gameObject;

                        }
                        sparkCheck = hit.collider.gameObject;

                            v.x = v.x - moveOffset;
                            vv.x = vv.x - moveOffset;
                            fallTo = vv;
                        

                        wallHit = true;
                    }
                }

            }
            else if ((Vector3.Dot(fallDirection, -transform.up) > 0.9f) && (Vector3.Dot(fallDirection, -transform.up) < 1.1f))
            {
                //print(" NEW DOT PRODUCT IS THE SAME");
                if (Physics.Raycast(transform.position, -transform.up, out hit, rayDistance, layermask))
                {
                    if (hit.collider.gameObject.tag == "Wall" || hit.collider.gameObject.tag == "death")
                    {

                        pX.SetActive(false);
                        pY.SetActive(true);
                        pZ.SetActive(false);

                        if (currentPlatform.GetComponent<MovingPlatform>() != null)
                        {
                            if (currentPlatform == hit.collider.GetComponentInParent<Perspective>())
                            {
                                movingWallHit = true;
                                movingWall = hit.collider.gameObject;
                                movingWallOffset = new Vector3(0, moveOffset, 0);
                            }

                        }
                        //player.Parent = hit.collider.gameObject.GetComponent<Perspective>().transform;
                        var v = hit.point;
                        sparkPoint = v;
                        if (hit.collider.gameObject.tag == "death")
                        {
                            v.y = v.y + moveOffset;
                            fallTo = v;
                        }
                        else
                        {
                            var vv = hit.collider.transform.position;
                            vv.y = vv.y + moveOffset;
                            fallTo = vv;
                        }
                        //var vv = hit.collider.gameObject.GetComponentInParent<Perspective>().transform.position;

                       // v.y = v.y + moveOffset;
                        //vv.y = vv.y + moveOffset;
                        //fallTo = v;
                        if (hit.transform.GetComponentInParent<Perspective>() != null)
                        {
                            sparkParent = hit.transform.GetComponentInParent<Perspective>().gameObject;

                        }
                        sparkCheck = hit.collider.gameObject;

                        if (hit.collider.gameObject.tag == "Wall")

                        {

                        }
                        //fallTo = v;

                        wallHit = true;

                    }
                    else if (hit.collider.gameObject.tag == "Ground")
                    {
                        pX.SetActive(false);
                        pY.SetActive(true);
                        pZ.SetActive(false);

                        var v = hit.point;
                        sparkPoint = v;
                        var vv = hit.collider.gameObject.GetComponentInParent<Perspective>().transform.position;

                        if (hit.transform.GetComponentInParent<Perspective>() != null)
                        {
                            sparkParent = hit.transform.GetComponentInParent<Perspective>().gameObject;

                        }
                        sparkCheck = hit.collider.gameObject;

                            v.y = v.y + moveOffset;
                            vv.y = vv.y + moveOffset;
                            fallTo = vv;
                        

                        wallHit = true;
                    }
                }


            }
            else if ((Vector3.Dot(fallDirection, transform.up) > 0.9f) && (Vector3.Dot(fallDirection, transform.up) < 1.1f))
            {

                //print(" NEW DOT PRODUCT IS THE SAME");
                if (Physics.Raycast(transform.position, transform.up, out hit, rayDistance, layermask))
                {
                    if (hit.collider.gameObject.tag == "Wall" || hit.collider.gameObject.tag == "death")
                    {
                        pX.SetActive(false);
                        pY.SetActive(true);
                        pZ.SetActive(false);

                        if (currentPlatform.GetComponent<MovingPlatform>() != null)
                        {
                            if (currentPlatform == hit.collider.GetComponentInParent<Perspective>())
                            {
                                movingWall = hit.collider.gameObject;
                                movingWallHit = true;
                                movingWallOffset = new Vector3(0, -moveOffset, 0);
                            }

                        }                      

                        //player.Parent = hit.collider.gameObject.GetComponent<Perspective>().transform;
                        var v = hit.point;
                        sparkPoint = v;
                        if (hit.collider.gameObject.tag == "death")
                        {
                            v.y = v.y - moveOffset;
                            fallTo = v;
                        }
                        else
                        {
                            var vv = hit.collider.transform.position;
                            vv.y = vv.y - moveOffset;
                            fallTo = vv;
                        }
                        //var vv = hit.collider.gameObject.GetComponentInParent<Perspective>().transform.position;
                        //v.y = v.y - moveOffset;
                        //vv.y = vv.y - moveOffset;
                        //fallTo = v;
                        if (hit.transform.GetComponentInParent<Perspective>() != null)
                        {
                            sparkParent = hit.transform.GetComponentInParent<Perspective>().gameObject;

                        }
                        sparkCheck = hit.collider.gameObject;

                        if (hit.collider.gameObject.tag == "Wall")
                        {

                        }


                        wallHit = true;
                    }
                    else if (hit.collider.gameObject.tag == "Ground")
                    {
                        pX.SetActive(false);
                        pY.SetActive(true);
                        pZ.SetActive(false);

                        var v = hit.point;
                        sparkPoint = v;
                        var vv = hit.collider.gameObject.GetComponentInParent<Perspective>().transform.position;

                        if (hit.transform.GetComponentInParent<Perspective>() != null)
                        {
                            sparkParent = hit.transform.GetComponentInParent<Perspective>().gameObject;

                        }
                        sparkCheck = hit.collider.gameObject;

                            v.y = v.y - moveOffset;
                            vv.y = vv.y - moveOffset;
                            fallTo = vv;
                        

                        //fallTo = v;


                        wallHit = true;
                    }
                }

            }
            else if ((Vector3.Dot(fallDirection, -transform.forward) > 0.9f) && (Vector3.Dot(fallDirection, -transform.forward) < 1.1f))
            {
                //print(" NEW DOT PRODUCT IS THE SAME");
                if (Physics.Raycast(transform.position, -transform.forward, out hit, rayDistance, layermask))
                {
                    if (hit.collider.gameObject.tag == "Wall" || hit.collider.gameObject.tag == "death")
                    {

                        pX.SetActive(false);
                        pY.SetActive(false);
                        pZ.SetActive(true);

                        if (currentPlatform.GetComponent<MovingPlatform>() != null)
                        {
                            if (currentPlatform == hit.collider.GetComponentInParent<Perspective>())
                            {
                                movingWall = hit.collider.gameObject;
                                movingWallHit = true;
                                movingWallOffset = new Vector3(0, 0, moveOffset);
                            }

                        } else
                        {

                        }
                        //player.Parent = hit.collider.gameObject.GetComponent<Perspective>().transform;
                        var v = hit.point;

                        sparkPoint = v;
                        if (hit.collider.gameObject.tag == "death")
                        {
                            v.z = v.z + moveOffset;
                            fallTo = v;
                        }
                        else
                        {
                            var vv = hit.collider.transform.position;
                            vv.z = vv.z + moveOffset;
                            fallTo = vv;
                        }
                        //var vv = hit.collider.gameObject.GetComponentInParent<Perspective>().transform.position;

                        //v.z = v.z + moveOffset;
                       // vv.y = vv.z + moveOffset;
                        //fallTo = v;
                        if (hit.transform.GetComponentInParent<Perspective>() != null)
                        {
                            sparkParent = hit.transform.GetComponentInParent<Perspective>().gameObject;

                        }
                        sparkCheck = hit.collider.gameObject;

                        if (hit.collider.gameObject.tag == "Wall")
                        {

                        }


                        wallHit = true;
                    }
                    else if (hit.collider.gameObject.tag == "Ground")
                    {
                        pX.SetActive(false);
                        pY.SetActive(false);
                        pZ.SetActive(true);

                        var v = hit.point;
                        sparkPoint = v;
                        var vv = hit.collider.gameObject.GetComponentInParent<Perspective>().transform.position;

                        if (hit.transform.GetComponentInParent<Perspective>() != null)
                        {
                            sparkParent = hit.transform.GetComponentInParent<Perspective>().gameObject;

                        }
                        sparkCheck = hit.collider.gameObject;

                            v.z = v.z + moveOffset;
                            vv.y = vv.z + moveOffset;
                            fallTo = vv;
                        


                        wallHit = true;
                    }
                }

            }
            else if ((Vector3.Dot(fallDirection, transform.forward) > 0.9f) && (Vector3.Dot(fallDirection, transform.forward) < 1.1f))
            {
                //print(" NEW DOT PRODUCT IS THE SAME");
                if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, layermask))
                {
                    if (hit.collider.gameObject.tag == "Wall" || hit.collider.gameObject.tag == "death")
                    {
                        pX.SetActive(false);
                        pY.SetActive(false);
                        pZ.SetActive(true);

                        if (currentPlatform.GetComponent<MovingPlatform>() != null)
                        {
                            if (currentPlatform == hit.collider.GetComponentInParent<Perspective>())
                            {
                                movingWall = hit.collider.gameObject;
                                movingWallHit = true;
                                movingWallOffset = new Vector3(0, 0, -moveOffset);
                            }


                        }
                        else
                        {

                        }
                        //player.Parent = hit.collider.gameObject.GetComponentInParent<Perspective>().transform;
                        var v = hit.point;
                        sparkPoint = v;
                        if (hit.collider.gameObject.tag == "death")
                        {
                            v.z = v.z - moveOffset;
                            fallTo = v;
                        }
                        else
                        {
                            var vv = hit.collider.transform.position;
                            vv.z = vv.z - moveOffset;
                            fallTo = vv;
                        }
                        //var vv = hit.collider.gameObject.GetComponentInParent<Perspective>().transform.position;

                       // v.z = v.z - moveOffset;
                        //vv.y = vv.z - moveOffset;
                        //fallTo = v;
                        if (hit.transform.GetComponentInParent<Perspective>() != null)
                        {
                            sparkParent = hit.transform.GetComponentInParent<Perspective>().gameObject;

                        }
                        sparkCheck = hit.collider.gameObject;

                        if (hit.collider.gameObject.tag == "Wall")

                        {

                        }

                        wallHit = true;
                    }
                    else if (hit.collider.gameObject.tag == "Ground")
                    {
                        pX.SetActive(false);
                        pY.SetActive(false);
                        pZ.SetActive(true);

                        var v = hit.point;
                        sparkPoint = v;
                        var vv = hit.collider.gameObject.GetComponentInParent<Perspective>().transform.position;

                        if (hit.transform.GetComponentInParent<Perspective>() != null)
                        {
                            sparkParent = hit.transform.GetComponentInParent<Perspective>().gameObject;

                        }
                        sparkCheck = hit.collider.gameObject;

                            v.z = v.z - moveOffset;
                            vv.y = vv.z - moveOffset;
                            fallTo = vv;
                        

                        wallHit = true;
                    }
                }
            }

            //THIS USED TO BE THERE && movingWallHit == false, makes player not die on boundry, but fixes landing on moving platforms
            if (wallHit == true && moving == false && camera.GetComponentInParent<Rotate>().turning == false)
            {
                
                if (hit.collider.tag == "death")
                {
                    player.Parent = hit.collider.gameObject.transform;
                } else
                {
                    player.Parent = hit.collider.gameObject.transform;
                    //player.Parent = hit.collider.gameObject.GetComponentInParent<Perspective>().transform;
                }
                
               //
                


                if ( movingWallHit == false)
                {
                    StartCoroutine(Move(this.transform, fallTo, 0.5f));
                }

                if (hit.collider.tag == "death")
                {
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Spikes"))
                    {
                        spikeDeath = true;
                    }
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Boundry"))
                    {
                        boundryDeath = true;
                    }
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
                    {
                        wallDeath = true;
                    }
                    killAfterFall = true;
                }
            }

        }

        if (movingWallHit == true && moving == false && camera.GetComponentInParent<Rotate>().turning == false)
        {
            //NEW!!!
            /*
            if (hit.collider.tag == "death" && hit.collider != null)
            {
                killAfterFall = true;
            }
            */
            player.Parent = movingWall.transform;

            fallToMovingWall = movingWall.transform.position + movingWallOffset;

            i -= Time.deltaTime;
            if (i <= 0)
            {
                if (currentPlatform.GetComponent<MovingPlatform>() != null && currentPlatform.GetComponent<MovingPlatform>().moving == false)
                {
                    
                    wallHit = false;
                    StartCoroutine(Move(this.transform, fallToMovingWall, 0.5f));
                    movingWallHit = false;
                    i = 0.2f;
                }
                
            }

        }




    }



    public IEnumerator Move(Transform thisTransform, Vector3 target, float time)
    {
        GM.instance.IncrementGravityShifts();
        ScriptManager.instance.ResetRotationsBeforeFall();
        startPositions = thisTransform.position;

        GM.instance.TurnSound();
        //print("FALL called");
        moving = true;
        Vector3 startPosition = startPositions;
        Vector3 endPosition =  target;

        var d = Vector3.Distance(startPosition, target);
        if (d <= 1)
        {
            ScriptManager.instance.NoFallUtterance();
        }
        

        float rate = 1.0f / time;
        float t = 0.0f;
        //Camera.main.orthographic = false;
        while (t < 1.0f)
        {
            t += Time.deltaTime * rate;
            thisTransform.position = new Vector3(Mathf.Lerp(startPosition.x, endPosition.x, Mathf.SmoothStep(0.0f, 1f, t)), Mathf.Lerp(startPosition.y, endPosition.y, Mathf.SmoothStep(0.0f, 1f, t)), Mathf.Lerp(startPosition.z, endPosition.z, Mathf.SmoothStep(0.0f, 1f, t)));

            yield return null;
        }
        //Camera.main.orthographic = true;

        if (sparkCheck != null && sparkCheck.tag == "Ground")
        {
            print("!!!!!!!!!!!!!");
            var s = Instantiate(groundSparks, sparkPoint, Quaternion.LookRotation(fallDirection));
            s.transform.parent = sparkParent.transform;
            GM.instance.GroundHitSound();
            Destroy(s, 2f);

        }
        if (sparkCheck != null && sparkCheck.tag == "Wall")
        { 
            print("!!!!!!!!!!!!!");
            print(sparkCheck);
            var s = Instantiate(impactSparks, sparkPoint, Quaternion.LookRotation(fallDirection));
            s.transform.parent = sparkParent.transform;
            GM.instance.WallHitSound();
            Destroy(s, 2f);
        }
        


        moving = false;
        wallHit = false;
        if (killAfterFall == true)
        {
            GM.instance.DeathSound();
            if (wallDeath == true)
            {
                ScriptManager.instance.DeathFromWallUtterance();
            }
            if (boundryDeath == true)
            {
                ScriptManager.instance.DeathFromBoundryUtterance();
            }
            if (spikeDeath == true)
            {
                ScriptManager.instance.DeathBySpikesUtterance();
            }
            GM.instance.GameOver();
            
            this.GetComponent<Player>().DeathParticles();
            Destroy(this.gameObject);
        }
    }

}
