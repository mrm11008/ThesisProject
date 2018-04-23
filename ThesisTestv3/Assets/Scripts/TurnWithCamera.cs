using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWithCamera : MonoBehaviour {

    public Rotate pivot;
    public Vector3 offset;
    private ParticleSystem p;

    private float t = 0.3f;

    public float rotateTime = 2f;
    public float rotateSidewaysTime =2f;
    // Use this for initialization
    void Start () {
        p = this.GetComponent<ParticleSystem>();

	}
	
	// Update is called once per frame
	void Update () {

        //this.transform.position = -pivot.transform.position;
       // var r = this.transform.rotation.eulerAngles;
        //r = -pivot.transform.rotation.eulerAngles;
        //r = pivot.particleDirection;
        //this.transform.rotation = Quaternion.Euler(r);

        //p.GetComponent<ParticleEmitter>().localVelocity = new Vector3(10, 0, 0);
        //if (pivot.turning == true)
        //{
            //var force1 = p.forceOverLifetime;
            //force1.x = -pivot.transform.forward.x * 3;
            //force1.x = -pivot.particleDirection.x*3;
            //force1.y = -pivot.particleDirection.y*3;
            //force1.z = -pivot.particleDirection.z*3;
      //  } else
      //  {
            /*
           var force1 = p.forceOverLifetime;
           force1.x = 0;
           force1.y = 0;
           force1.z = 0;
           */
      //  }

        if (Input.GetKeyDown(KeyCode.W))
        {
            //p.gameObject.SetActive(true);
            var force1 = p.forceOverLifetime;
            ////force1.x = -pivot.transform.forward.x * 300;
            //force1.y = -pivot.transform.forward.y * 300;
            //force1.z = -pivot.transform.forward.z * 300;

            //force.x = 1000f;
            //force.y = 0;
            //force.z = 0;
            //var force1 = p.forceOverLifetime;
            //force1.x = 20f;
            //force1.y = 20f;
            //t = 0.3f;
            //AnimationCurve curve = new AnimationCurve();
            //curve.AddKey(0.0f, 0.1f);
            //curve.AddKey(0.75f, 1.0f);
            //force.x = new ParticleSystem.MinMaxCurve(1.5f, curve);

        }
        else
        {

            t -= Time.deltaTime;
            if (t <= 0)
            {
                //p.gameObject.SetActive(false);
                //var force1 = p.forceOverLifetime;
               // force1.x = 0f;
               // force1.y = 0f;
                
            }

        }

        /*
        if (Input.GetKeyDown(KeyCode.D))
        {
            var force1 = p.forceOverLifetime;
            force1.x = -pivot.transform.right.x * 300;
            force1.y = -pivot.transform.right.y * 300;
            force1.z = -pivot.transform.right.z * 300;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            var force1 = p.forceOverLifetime;
            force1.x = pivot.transform.right.x * 300;
            force1.y = pivot.transform.right.y * 300;
            force1.z = pivot.transform.right.z * 300;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            var force1 = p.forceOverLifetime;
            force1.x = -pivot.transform.forward.x * 200;
            force1.y = -pivot.transform.forward.y * 200;
            force1.z = -pivot.transform.forward.z * 200;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            var force1 = p.forceOverLifetime;
            force1.x = -pivot.transform.up.x * 200;
            force1.y = -pivot.transform.up.y * 200;
            force1.z = -pivot.transform.up.z * 200;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            var force1 = p.forceOverLifetime;
            force1.x = -pivot.transform.up.x * 200;
            force1.y = -pivot.transform.up.y * 200;
            force1.z = -pivot.transform.up.z * 200;
        }
        */
    }

    void LateUpdate()
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(90f, 0f, 0f));



        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {

            StartCoroutine(Rotation(this.transform, new Vector3(90, 0, 0), rotateTime));
            

        }

        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) )
        {

            StartCoroutine(Rotation(this.transform, new Vector3(-90, 0, 0), rotateTime));

        }


        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) )
        {

            StartCoroutine(Rotation(this.transform, new Vector3(0, -90, 0), rotateTime));


        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) )
        {

            StartCoroutine(Rotation(this.transform, new Vector3(0, 90, 0), rotateTime));

        }
        if (Input.GetKeyDown(KeyCode.Q) )
        {

            StartCoroutine(Rotation(this.transform, new Vector3(-90, 45, 0), rotateSidewaysTime));
            GM.instance.IncrementRotations();

        }
        if (Input.GetKeyDown(KeyCode.E) )
        {

            StartCoroutine(Rotation(this.transform, new Vector3(90, -45, 0), rotateSidewaysTime));

        }
    }

    public IEnumerator Rotation(Transform thisTransform, Vector3 degrees, float time)
    {
        GM.instance.TurnSound();
        print("Rotate called");
        //turning = true;
        //particleDirection = degrees;
        Quaternion startRotation = thisTransform.rotation;
        Quaternion endRotation = thisTransform.rotation * Quaternion.Euler(-degrees);
        float rate = 1.0f / time;
        float t = 0.0f;
        //Camera.main.orthographic = false;
        while (t < 1.0f)
        {
            t += Time.deltaTime * rate;
            thisTransform.rotation = Quaternion.Slerp(startRotation, endRotation, Mathf.SmoothStep(0.0f, 1f, t));
            yield return null;
        }
        //Camera.main.orthographic = true;
        //turning = false;
    }
}
