using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFeedback : MonoBehaviour {

	public AudioSource audso;

	public AudioClip[] hcharRotations;

	public AudioClip[] acharRotations;

	// Use this for initialization
	void Start () {
		audso = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {


	}


	public void PlayHappyRotationFeedback() {
		var i = Random.Range (0, hcharRotations.Length);
		audso.PlayOneShot (hcharRotations [i]);
	}

	public void PlayAngryRotationFeedback() {
		var i = Random.Range (0, acharRotations.Length);
		audso.PlayOneShot (acharRotations [i]);
	}
}
