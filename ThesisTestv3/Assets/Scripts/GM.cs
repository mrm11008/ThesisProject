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
    public AudioClip wallHit;
    public AudioClip deathSound;
    public AudioClip groundHit;


    //GAMEOVER
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject scoreScreen;
    public GameObject pauseScreen;

    private bool winoverScreen = false;
    private bool pauseToggle = false;

    private Player player;
    private Fall fall;

    public LevelManager currentLevelManager;

    public int numCoinsNeeded = 0;

    public bool levelComplete = false;

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
        levelComplete = false;
        player = FindObjectOfType<Player>();
        fall = player.GetComponent<Fall>();
		audso = this.GetComponent<AudioSource> ();
        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);

        currentLevelManager = FindObjectOfType<LevelManager>();
        numCoinsNeeded = currentLevelManager.coinsNeeded;
    }
	
	// Update is called once per frame
	void Update () {


        if (levelComplete == true)
        {
            if (ScriptManager.instance.isPlaying() == false)
            {
                winScreen.SetActive(true);
                //levelComplete = false;
            }

        }

        if (winScreen.activeSelf == true || gameOverScreen.activeSelf == true)
        {
            winoverScreen = true;
        } else
        {
            winoverScreen = false;
        }   

        if (Input.GetKeyDown(KeyCode.Escape) && winoverScreen == false)
        {
            if (pauseToggle)
            {
                ScriptManager.instance.audso.UnPause();
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            } else
            {
                ScriptManager.instance.audso.Pause();

                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }
            pauseToggle = !pauseToggle;
        }

        if (winScreen.activeSelf == true || gameOverScreen.activeSelf == true || pauseScreen.activeSelf == true)
        {
            scoreScreen.SetActive(true);
        }
        else
        {
            scoreScreen.SetActive(false);
        }




        if (Input.GetKeyDown (KeyCode.Space)) {
			
			//IncrementGravityShifts ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {

			//DeathReset ();
		}
		ScoreKeeper ();

        if (currentLevelManager == null)
        {
            currentLevelManager = FindObjectOfType<LevelManager>();

            numCoinsNeeded = currentLevelManager.coinsNeeded;
        }

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
        ScriptManager.instance.ResetElapsedTime();
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
        //SceneManager.LoadScene ("Playground - Copy");
        gameOverScreen.SetActive(false);
        coins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScriptManager.instance.RestartUtterance();
	}

    public void MainMenu()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
        pauseScreen.SetActive(false);
        levelComplete = false;
        ScriptManager.instance.audso.Stop();
        coins = 0;
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        print("gameover");
        gameOverScreen.SetActive(true);
    }
    public void ToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void NextLevel()
    {
        levelComplete = false;
        winScreen.SetActive(false);
        coins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        ScriptManager.instance.ResetPriority();
        ScriptManager.instance.LevelIntroductionUtterance(SceneManager.GetActiveScene().buildIndex + 1);


    }
    public void Win()
    {
        if (coins >= numCoinsNeeded && winScreen.activeSelf == false && fall.falling == false && levelComplete == false)
        {
            levelComplete = true;
            //winScreen.SetActive(true);
            ScriptManager.instance.LevelCompleteUtterance(SceneManager.GetActiveScene().buildIndex);
            currentLevelManager = FindObjectOfType<LevelManager>();
            currentLevelManager.WinExplode();
        } else if (coins < numCoinsNeeded)
        {
            if (fall.falling == false)
            {
                ScriptManager.instance.NotEnoughCoinsUttererance();

            }
            //ScriptManager.instance.CoinCollectUttererance();
        }

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
    public void WallHitSound()
    {
        audso.PlayOneShot(wallHit);
    }
    public void GroundHitSound()
    {
        audso.PlayOneShot(groundHit);
    }
    public void DeathSound()
    {
        print("ds");
        audso.PlayOneShot(deathSound);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        pauseToggle = !pauseToggle;
    }


}
