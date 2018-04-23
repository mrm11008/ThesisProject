using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public int coinsNeeded = 2;
    public ParticleSystem winparticle;
    public GameObject winBlock;

    public void WinExplode()
    {
        var s = Instantiate(winparticle, winBlock.transform.position, Quaternion.Euler(winBlock.transform.rotation.x, winBlock.transform.rotation.y, winBlock.transform.rotation.z));
        Destroy(s, 2f);
    }

}
