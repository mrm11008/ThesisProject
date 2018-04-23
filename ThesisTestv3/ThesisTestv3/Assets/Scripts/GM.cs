using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public int rotations = 0;
	public int gravityShifts = 0;
	public int coins = 0;

	public int rotationsBeforeShift = 0;
	public int gravityShiftCheck = 0;
	public bool gravityCheckTrigger = true;

	public static GM instance = null;

	//SCORE
	public Text rotationScore;
	public Text gravityShiftScore;
	public Text coinScore;

	public CharacterFeedback charFeedback;

	private AudioSource audso;
	public AudioClip turn;
	public AudioClip coinPickup;
	public AudioClip gravityActivate;
	public AudioClip hit;

	void Awake() {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);

		InitGame ();

	}


	void InitGame() {

	}

	// Use this for initialization
	void Start () {
		audso = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			
			//IncrementGravityShifts ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {

			DeathReset ();
		}
		ScoreKeeper ();
	}

	public void IncrementRotations() {
		if (gravityCheckTrigger == false) {
			rotationsBeforeShift = 0;
			gravityShiftCheck = gravityShifts;
		}
		gravityCheckTrigger = true;

		rotationsBeforeShift++;
		if (gravityShiftCheck == gravityShifts && rotationsBeforeShift > 4) {
			rotationsBeforeShift = 0;
			print ("play feedback");

		}
		rotations++;
	}
	public void IncrementGravityShifts() {
		gravityShifts++;
		gravityCheckTrigger = false;
	}

	public void IncrementCoins() {
		coins++;
	}

	public void ScoreKeeper() {

		gravityShiftScore.text = "Gravity Shifts: " + gravityShifts;
		rotationScore.text = "Rotations: " + rotations;
		coinScore.text = "Coins: " + coins;
	}


	public void DeathReset() {
		SceneManager.LoadScene ("TestScenev3 - Copy");
	}


	public void TurnSound() {
		audso.PlayOneShot (turn);
	}
	public void CoinSound() {
		audso.PlayOneShot (coinPickup);
	}
	public void GravitySound() {
		audso.PlayOneShot (gravityActivate);
	}
	public void HitSound() {
		audso.PlayOneShot (hit);
	}
}
