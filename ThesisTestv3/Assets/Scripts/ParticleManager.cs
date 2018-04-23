using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {
    private ParticleSystem[] pSystems;

    public Rotate pivot;
    public Vector3 cameraDirection;

    public bool cornerRotate = true;
    private float t = 1.0f;
	// Use this for initialization
	void Start () {
        pSystems = GetComponentsInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

        cameraDirection = pivot.transform.forward;

        if (pivot.turning == true)
        {
            foreach(ParticleSystem ps in pSystems)
            {
                var em = ps.emission;
                em.rateOverTime = 1000;
                //em = ParticleSystem.EmissionModule;
            }
        } else
        {
            foreach (ParticleSystem ps in pSystems)
            {
                var em = ps.emission;
                em.rateOverTime = 0;
                var force1 = ps.forceOverLifetime;
                force1.x = 0;
                force1.y = 0;
                force1.z = 0;
                //em = ParticleSystem.EmissionModule;
            }
        }

        if (cornerRotate == true)
        {
            //print("asd");
            foreach (ParticleSystem ps in pSystems)
            {
                //print(ps.gameObject.transform.position.x);
                if (ps.gameObject.transform.position.x < 0 && ps.gameObject.transform.position.z < 0)
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        //var force1 = ps.forceOverLifetime;
                        //force1.x = 200;
                        //force1.y = 0;
                        //force1.z = -200;
                    }
                }
                
            }
        }

        foreach (ParticleSystem ps in pSystems)
        {

            if (((Vector3.Dot(cameraDirection, ps.gameObject.transform.up) > 0.9f) && (Vector3.Dot(cameraDirection, ps.gameObject.transform.up) < 1.1f) && pivot.turning == false))
            {
                if ((ps.gameObject.transform.position.x < 0 && ps.gameObject.transform.position.z < 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = 0;
                        force1.z = 200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = 0;
                        force1.z =-200;
                    }
                    if (ps.gameObject.transform.position.y > 0)
                    {
                        if (Input.GetKeyDown(KeyCode.W) && pivot.turning == false)
                        {
                            var force1 = ps.forceOverLifetime;
                            force1.x = 0;
                            force1.y = 200;
                            force1.z = 200;
                        }
                        if (Input.GetKeyDown(KeyCode.S) && pivot.turning == false)
                        {
                            var force1 = ps.forceOverLifetime;
                            force1.x = 0;
                            force1.y = -200;
                            force1.z = -200;
                        }
                        if (Input.GetKeyDown(KeyCode.A) && pivot.turning == false)
                        {
                            var force1 = ps.forceOverLifetime;
                            force1.x = -200;
                            force1.y = 200;
                            force1.z = 0;
                        }

                        if (Input.GetKeyDown(KeyCode.D) && pivot.turning == false)
                        {
                            var force1 = ps.forceOverLifetime;
                            force1.x = 200;
                            force1.y = -200;
                            force1.z = 0;
                        }
                    } else
                    {
                        /*
                        if (Input.GetKeyDown(KeyCode.W) && pivot.turning == false)
                        {
                            var force1 = ps.forceOverLifetime;
                            force1.x = 0;
                            force1.y = 200;
                            force1.z = -200;
                        }
                        if (Input.GetKeyDown(KeyCode.S) && pivot.turning == false)
                        {
                            var force1 = ps.forceOverLifetime;
                            force1.x = 0;
                            force1.y = -200;
                            force1.z = 200;
                        }
                        */
                    }
                    
                }
                if (ps.gameObject.transform.position.x > 0 && ps.gameObject.transform.position.z > 0)
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = 0;
                        force1.z = -200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = 0;
                        force1.z = 200;
                    }




                }
                if ((ps.gameObject.transform.position.x > 0 && ps.gameObject.transform.position.z < 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = 0;
                        force1.z = -200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = 0;
                        force1.z = 200;
                    }
                    if (Input.GetKeyDown(KeyCode.W) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.y = 200;
                        force1.z = 200;
                    }
                }
                if ((ps.gameObject.transform.position.x < 0 && ps.gameObject.transform.position.z > 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = 0;
                        force1.z = 200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = 0;
                        force1.z = -200;
                    }
                }
            }
            else if (((Vector3.Dot(cameraDirection, -ps.gameObject.transform.up) > 0.9f) && (Vector3.Dot(cameraDirection, -ps.gameObject.transform.up) < 1.1f)) && pivot.turning == false)
            {
                if ((ps.gameObject.transform.position.x < 0 && ps.gameObject.transform.position.z < 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = 0;
                        force1.z = -200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = 0;
                        force1.z = 200;
                    }
                }
                if (ps.gameObject.transform.position.x > 0 && ps.gameObject.transform.position.z > 0)
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = 0;
                        force1.z = 200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = 0;
                        force1.z = -200;
                    }
                }
                if ((ps.gameObject.transform.position.x > 0 && ps.gameObject.transform.position.z < 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = 0;
                        force1.z = 200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = 0;
                        force1.z = -200;
                    }
                }
                if ((ps.gameObject.transform.position.x < 0 && ps.gameObject.transform.position.z > 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = 0;
                        force1.z = -200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = 0;
                        force1.z = 200;
                    }
                }
            }
            
            

            if (((Vector3.Dot(cameraDirection, ps.gameObject.transform.forward) > 0.9f) && (Vector3.Dot(cameraDirection, ps.gameObject.transform.forward) < 1.1f) && pivot.turning == false))
            {
                if ((ps.gameObject.transform.position.x < 0 && ps.gameObject.transform.position.y < 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = -200;
                        force1.z = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = 200;
                        force1.z = 0;
                    }
                }
                if (ps.gameObject.transform.position.x > 0 && ps.gameObject.transform.position.y > 0)
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = 200;
                        force1.z = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = -200;
                        force1.z = 0;
                    }
                }
                if ((ps.gameObject.transform.position.x > 0 && ps.gameObject.transform.position.y < 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = 200;
                        force1.z = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = -200;
                        force1.z = 0;
                    }
                }
                if ((ps.gameObject.transform.position.x < 0 && ps.gameObject.transform.position.y > 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = -200;
                        force1.z = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = 200;
                        force1.z = 0;
                    }
                }

            }
            else if (((Vector3.Dot(cameraDirection, -ps.gameObject.transform.forward) > 0.9f) && (Vector3.Dot(cameraDirection, -ps.gameObject.transform.forward) < 1.1f)) && pivot.turning == false)
            {
                if ((ps.gameObject.transform.position.x < 0 && ps.gameObject.transform.position.y < 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = 200;
                        force1.z = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = -200;
                        force1.z = 0;
                    }
                }
                if (ps.gameObject.transform.position.x > 0 && ps.gameObject.transform.position.y > 0)
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = -200;
                        force1.z = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = 200;
                        force1.z = 0;
                    }
                }
                if ((ps.gameObject.transform.position.x > 0 && ps.gameObject.transform.position.y < 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = -200;
                        force1.z = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = 200;
                        force1.z = 0;
                    }
                }
                if ((ps.gameObject.transform.position.x < 0 && ps.gameObject.transform.position.y > 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 200;
                        force1.y = 200;
                        force1.z = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = -200;
                        force1.y = -200;
                        force1.z = 0;
                    }
                }



            }
            

            if (((Vector3.Dot(cameraDirection, ps.gameObject.transform.right) > 0.9f) && (Vector3.Dot(cameraDirection, ps.gameObject.transform.right) < 1.1f)) && pivot.turning == false)
            {
                if ((ps.gameObject.transform.position.z < 0 && ps.gameObject.transform.position.y < 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = -200;
                        force1.y = 200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = 200;
                        force1.y = -200;
                    }
                }
                if (ps.gameObject.transform.position.z > 0 && ps.gameObject.transform.position.y > 0)
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = 200;
                        force1.y = -200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = -200;
                        force1.y = 200;
                    }
                }
                if ((ps.gameObject.transform.position.z > 0 && ps.gameObject.transform.position.y < 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = -200;
                        force1.y = -200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = 200;
                        force1.y = 200;
                    }
                }
                if ((ps.gameObject.transform.position.z < 0 && ps.gameObject.transform.position.y > 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = 200;
                        force1.y = 200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = -200;
                        force1.y = -200;
                    }
                }
            }
            else if (((Vector3.Dot(cameraDirection, -ps.gameObject.transform.right) > 0.9f) && (Vector3.Dot(cameraDirection, -ps.gameObject.transform.right) < 1.1f)) && pivot.turning == false)
            {
                if ((ps.gameObject.transform.position.z < 0 && ps.gameObject.transform.position.y < 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = 200;
                        force1.y = -200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = -200;
                        force1.y = 200;
                    }
                }
                if (ps.gameObject.transform.position.z > 0 && ps.gameObject.transform.position.y > 0)
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = -200;
                        force1.y = 200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = 200;
                        force1.y = -200;
                    }
                }
                if ((ps.gameObject.transform.position.z > 0 && ps.gameObject.transform.position.y < 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = 200;
                        force1.y = 200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = -200;
                        force1.y = -200;
                    }
                }
                if ((ps.gameObject.transform.position.z < 0 && ps.gameObject.transform.position.y > 0))
                {

                    if (Input.GetKeyDown(KeyCode.E) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = -200;
                        force1.y = -200;
                    }
                    if (Input.GetKeyDown(KeyCode.Q) && pivot.turning == false)
                    {
                        var force1 = ps.forceOverLifetime;
                        force1.x = 0;
                        force1.z = 200;
                        force1.y = 200;
                    }
                }
            }

        }
        


    }
}
