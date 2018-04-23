using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour {


    private int sideCount = 6;

    public GameObject[] asteroids;
    private GameObject asteroidToSpawn;



    // Use this for initialization
    void Start () {
        int asteroidPerSide = 15;


        for (int i = 1; i < sideCount + 1; i++)
        {
            var ast = Random.Range(0, 13);
            asteroidToSpawn = asteroids[ast];
            if (i == 1)
            {
                //positive x range
                for (int z = 0; z < asteroidPerSide; z++)
                {
                    var ast2 = Random.Range(0, 13);
                    asteroidToSpawn = asteroids[ast2];
                    Vector3 pos = new Vector3(Random.Range(30, 60), Random.Range(-150, 150), Random.Range(100, -100));
                    var a = Instantiate(asteroidToSpawn, pos, Quaternion.identity);
                    a.transform.parent = this.transform;
                }
            }
            if (i == 2)
            {
                //negative x range
                for (int z = 0; z < asteroidPerSide; z++)
                {
                    var ast3 = Random.Range(0, 13);
                    asteroidToSpawn = asteroids[ast3];
                    Vector3 pos = new Vector3(Random.Range(-30, -60), Random.Range(-150, 150), Random.Range(100, -100));
                    var a = Instantiate(asteroidToSpawn, pos, Quaternion.identity);
                    a.transform.parent = this.transform;
                }
            }
            if (i == 3)
            {
                //positive y range
                for (int z = 0; z < asteroidPerSide; z++)
                {
                    var ast4 = Random.Range(0, 13);
                    asteroidToSpawn = asteroids[ast4];
                    Vector3 pos = new Vector3(Random.Range(-100, 100), Random.Range(30, 60), Random.Range(75, -75));
                    var a = Instantiate(asteroidToSpawn, pos, Quaternion.identity);
                    a.transform.parent = this.transform;
                }
            }
            if (i == 4)
            {
                //negative y range
                for (int z = 0; z < asteroidPerSide; z++)
                {
                    var ast5 = Random.Range(0, 13);
                    asteroidToSpawn = asteroids[ast5];
                    Vector3 pos = new Vector3(Random.Range(-100, 100), Random.Range(-30, -60), Random.Range(75, -75));
                    var a = Instantiate(asteroidToSpawn, pos, Quaternion.identity);
                    a.transform.parent = this.transform;
                }
            }
            if (i == 5)
            {
                //positive z range
                for (int z = 0; z < asteroidPerSide; z++)
                {
                    var ast6 = Random.Range(0, 13);
                    asteroidToSpawn = asteroids[ast6];
                    Vector3 pos = new Vector3(Random.Range(-100, 100), Random.Range(-75, 75), Random.Range(60, 30));
                    var a = Instantiate(asteroidToSpawn, pos, Quaternion.identity);
                    a.transform.parent = this.transform;
                }
            }
            if (i == 6)
            {
                //positive z range
                for (int z = 0; z < asteroidPerSide; z++)
                {
                    var ast7 = Random.Range(0, 13);
                    asteroidToSpawn = asteroids[ast7];
                    Vector3 pos = new Vector3(Random.Range(-100, 100), Random.Range(-75, 75), Random.Range(-30, -60));
                    var a = Instantiate(asteroidToSpawn, pos, Quaternion.identity);
                    a.transform.parent = this.transform;
                }
            }

        }
    }
	
	// Update is called once per frame
	void Update () {



        
	}
}
