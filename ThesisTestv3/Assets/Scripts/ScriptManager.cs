using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptManager : MonoBehaviour {

    public static ScriptManager instance = null;

    public AudioSource audso;
    public AudioClip clipOne;
    public AudioClip clipTwo;

    public int rotationsBeforeFall;

    //Code to cut an utterance short
    [System.Serializable]
    public struct ScriptUtterance
    {
        public AudioClip clip;
        public int priority;
    }

    public bool angryChar = true;

    private bool coinWithoutMoveToggle = false;
    private bool finishWithoutCoinToggle = false;
    private bool firstMovingPlatformToggle = false;
    private bool firstSidewaysPlatformToggle = false;

    //HAPPY
    public ScriptUtterance happyInstructionUtterance;
    public ScriptUtterance[] happyIntroUtterances;
    public ScriptUtterance[] happyLevelIntroUtterances;
    public ScriptUtterance[] happyRotationUtterances;
    public ScriptUtterance[] happyCircleUtterances;
    public ScriptUtterance[] happyQEUtterances;
    public ScriptUtterance[] happyElapsedTimeUtterances;
    public ScriptUtterance happyCoinWithoutMoveUtterance;
    public ScriptUtterance happyFinishWithoutCoinsUtterance;
    public ScriptUtterance happyFirstMovingPlatformUtterance;
    public ScriptUtterance happyFirstSidewaysPlatformUtterance;

    public ScriptUtterance[] happyLevelCompleteUtterances;
    public ScriptUtterance[] happyNoFallUtterances;
    public ScriptUtterance[] happyDeathUtterances;
    public ScriptUtterance[] happyRespawnUtterances;
    public ScriptUtterance[] happyRespawnWallUtterances;
    public ScriptUtterance[] happyRespawnSpikeUtterances;
    public ScriptUtterance[] happyRespawnBoundryUtterances;
    public ScriptUtterance[] happyRotNoFallUtterances;


    //ANGRY
    public ScriptUtterance angryInstructionUtterance;
    public ScriptUtterance[] angryIntroUtterances;
    public ScriptUtterance[] angryLevelIntroUtterances;
    public ScriptUtterance[] angryRotationUtterances;
    public ScriptUtterance[] angryCircleUtterances;
    public ScriptUtterance[] angryQEUtterances;
    public ScriptUtterance[] angryElapsedTimeUtterances;

    public ScriptUtterance angryCoinWithoutMoveUtterance;
    public ScriptUtterance angryFinishWithoutCoinsUtterance;
    public ScriptUtterance angryFirstMovingPlatformUtterance;
    public ScriptUtterance angryFirstSidewaysPlatformUtterance;

    public ScriptUtterance[] angryLevelCompleteUtterances;
    public ScriptUtterance[] angryNoFallUtterances;
    public ScriptUtterance[] angryDeathUtterances;
    public ScriptUtterance[] angryRespawnUtterances;
    public ScriptUtterance[] angryRespawnWallUtterances;
    public ScriptUtterance[] angryRespawnSpikeUtterances;
    public ScriptUtterance[] angryRespawnBoundryUtterances;
    public ScriptUtterance[] angryRotNoFallUtterances;



    //in a row
    private int wCount;
    private int sCount;
    private int dCount;
    private int aCount;
    private int qCount;
    private int eCount;

    private int notQECount;


    public float elapsedTime = 20f;

    private float startTime;
    private ScriptUtterance currentClip;
    private ScriptUtterance reset;

    public ScriptUtterance clip;
    public ScriptUtterance clip2;

    private bool introComplete = false;
    private float introCompleteCheck;

    private bool deathByWall = false;
    private bool deathByBoundry = false;
    private bool deathBySpike = false;

    public int currentPriority;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad (gameObject);


    }

    private void Start()
    {
        //example code
        clip.clip = clipOne;
        clip.priority = 2;
        clip2.clip = clipTwo;
        clip2.priority = 1;
        audso = this.GetComponent<AudioSource>();
        
        if (angryChar == true)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                PlayScript("intro", "angry");
            } else
            {
                LevelIntroductionUtterance(SceneManager.GetActiveScene().buildIndex);
            }
            
        } else
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                PlayScript("intro", "happy");
            }
            else
            {
                LevelIntroductionUtterance(SceneManager.GetActiveScene().buildIndex);
            }
        }
        

    }

    public void PlayScript(string category, string emotion)
    {
        if (category == "intro" && emotion == "happy")
        {
            print("play lvl 1 intro");
            var l = happyIntroUtterances.Length;
            var i = Random.Range(0, l);
            audso.PlayOneShot(happyIntroUtterances[0].clip);
            //isPlayingCheck
            startTime = Time.time;
            currentClip = happyIntroUtterances[0];
            introComplete = true;
            //currentPriority = happyIntroUtterances[i].priority;
        }
        if (category == "intro" && emotion == "angry")
        {
            var l = angryIntroUtterances.Length;
            var i = Random.Range(0, l);
            audso.PlayOneShot(angryIntroUtterances[0].clip);
            startTime = Time.time;
            currentClip = angryIntroUtterances[0];
            introComplete = true;
            //currentPriority = angryIntroUtterances[i].priority;
        }
        if (category == "instructions" && emotion == "angry")
        {
            audso.PlayOneShot(angryInstructionUtterance.clip);
            startTime = Time.time;
            currentClip = angryInstructionUtterance;
            introComplete = false;
            //currentPriority = angryIntroUtterances[i].priority;
        }
        if (category == "instructions" && emotion == "happy")
        {
            audso.PlayOneShot(happyInstructionUtterance.clip);
            startTime = Time.time;
            currentClip = happyInstructionUtterance;
            introComplete = false;
            //currentPriority = angryIntroUtterances[i].priority;
        }
        if (category == "rotations" && emotion == "angry")
        {
            var l = angryRotationUtterances.Length;
            var i = Random.Range(0, l);
            if (currentClip.priority < angryRotationUtterances[i].priority)
            {
                audso.Stop();
                audso.PlayOneShot(angryRotationUtterances[i].clip);
                startTime = Time.time;
                currentClip = angryRotationUtterances[i];
                //currentPriority = angryRotationUtterances[i].priority;
            }

        }
        if (category == "nofall" && emotion == "angry")
        {
            var l = angryNoFallUtterances.Length;
            var i = Random.Range(0, l);
            if (currentClip.priority < angryNoFallUtterances[i].priority)
            {
                audso.Stop();
                audso.PlayOneShot(angryNoFallUtterances[i].clip);
                startTime = Time.time;
                currentClip = angryNoFallUtterances[i];
                //currentPriority = angryRotationUtterances[i].priority;
            }
        }
        if (category == "death" && emotion == "angry")
        {
            introComplete = false;
            var l = angryDeathUtterances.Length;
            var i = Random.Range(0, l);
            if (currentClip.priority < angryDeathUtterances[i].priority)
            {
                audso.Stop();
                audso.PlayOneShot(angryDeathUtterances[i].clip);
                startTime = Time.time;
                currentClip = angryDeathUtterances[i];
                //currentPriority = angryRotationUtterances[i].priority;
            }
        }
        if (category == "restart" && emotion == "angry")
        {
            introComplete = false;
            if (deathByBoundry == true)
            {
                var l = angryRespawnBoundryUtterances.Length;
                var i = Random.Range(0, l);
                if (currentClip.priority < angryRespawnBoundryUtterances[i].priority)
                {
                    audso.Stop();
                    audso.PlayOneShot(angryRespawnBoundryUtterances[i].clip);
                    startTime = Time.time;
                    currentClip = angryRespawnBoundryUtterances[i];
                }

            } else if(deathBySpike == true)
            {
                var l = angryRespawnSpikeUtterances.Length;
                var i = Random.Range(0, l);
                if (currentClip.priority < angryRespawnSpikeUtterances[i].priority)
                {
                    audso.Stop();
                    audso.PlayOneShot(angryRespawnSpikeUtterances[i].clip);
                    startTime = Time.time;
                    currentClip = angryRespawnSpikeUtterances[i];
                }
            }
            else if (deathByWall == true)
            {
                var l = angryRespawnWallUtterances.Length;
                var i = Random.Range(0, l);
                if (currentClip.priority < angryRespawnWallUtterances[i].priority)
                {
                    audso.Stop();
                    audso.PlayOneShot(angryRespawnWallUtterances[i].clip);
                    startTime = Time.time;
                    currentClip = angryRespawnWallUtterances[i];
                }
            }
            deathByWall = false;
            deathBySpike = false;
            deathByBoundry = false;

        }
        if (category == "restart" && emotion == "happy")
        {
            introComplete = false;
            if (deathByBoundry == true)
            {
                var l = happyRespawnBoundryUtterances.Length;
                var i = Random.Range(0, l);
                if (currentClip.priority < happyRespawnBoundryUtterances[i].priority)
                {
                    audso.Stop();
                    audso.PlayOneShot(happyRespawnBoundryUtterances[i].clip);
                    startTime = Time.time;
                    currentClip = happyRespawnBoundryUtterances[i];
                }

            }
            else if (deathBySpike == true)
            {
                var l = happyRespawnSpikeUtterances.Length;
                var i = Random.Range(0, l);
                if (currentClip.priority < happyRespawnSpikeUtterances[i].priority)
                {
                    audso.Stop();
                    audso.PlayOneShot(happyRespawnSpikeUtterances[i].clip);
                    startTime = Time.time;
                    currentClip = happyRespawnSpikeUtterances[i];
                }
            }
            else if (deathByWall == true)
            {
                var l = happyRespawnWallUtterances.Length;
                var i = Random.Range(0, l);
                if (currentClip.priority < happyRespawnWallUtterances[i].priority)
                {
                    audso.Stop();
                    audso.PlayOneShot(happyRespawnWallUtterances[i].clip);
                    startTime = Time.time;
                    currentClip = happyRespawnWallUtterances[i];
                }
            }
            deathByWall = false;
            deathBySpike = false;
            deathByBoundry = false;

        }

    }

    private void Update()
    {
        elapsedTime -= Time.deltaTime;
        if (elapsedTime <=0)
        {
            ElapsedTimeUtterance();
        }


        //Same key in a row
        if (wCount >= 4 || aCount >= 4 || sCount >= 4 || dCount >= 4 || qCount >= 4 || eCount >= 4)
        {
            CircleUtterance();
            ResetKeyCounts();
        }
        if (notQECount > 10)
        {
            QEUtterance();
            ResetQECount();
        }


        if (introComplete == true && isPlaying() == false && angryChar == true)
        {
            PlayScript("instructions", "angry");
        } else if (introComplete == true && isPlaying() == false && angryChar == false)
        {
            PlayScript("instructions", "happy");
        }
        if (isPlaying() == false)
        {
            currentClip = reset;
        }
        if (audso.isPlaying == false)
        {
            currentPriority = 0;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (currentPriority > clip2.priority)
            {
                //audso.Stop();
                //audso.PlayOneShot(clip2.clip);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //PlayScript("intro", "angry");

        }

    }

    public void PlayIntroUtterance()
    {
        if (angryChar == true)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                PlayScript("intro", "angry");
            }
            else
            {
                LevelIntroductionUtterance(SceneManager.GetActiveScene().buildIndex);
            }

        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                PlayScript("intro", "happy");
            }
            else
            {
                LevelIntroductionUtterance(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    //UTTERANCES
    public void NoFallUtterance()
    {
        print("You didnt even fall!");
        if (angryChar == true)
        {
            PlayScript("nofall", "angry");
        }
        else
        {
            //PlayScript("nofall", "happy");
            var l = happyNoFallUtterances.Length;
            var i = Random.Range(0, l);
            if (currentClip.priority < happyNoFallUtterances[i].priority)
            {
                audso.Stop();
                audso.PlayOneShot(happyNoFallUtterances[i].clip);
                startTime = Time.time;
                currentClip = happyNoFallUtterances[i];
                //currentPriority = angryRotationUtterances[i].priority;
            }
        }
    }
    
    public void RotationsUtterance()
    {
        //calling increment/reset in Fall and Rotate, resetting count after one utterance (might want to change)
        print("Round and round we go!!");
        if (angryChar == true)
        {
            PlayScript("rotations", "angry");
        } else
        {
            PlayScript("rotations", "happy");
        }
    }

    public void CircleUtterance()
    {
        //calling increment/reset in Fall and Rotate, resetting count after one utterance (might want to change)
        print("Round and round we go!!");
        ResetKeyCounts();
        if (angryChar == true)
        {
            //PlayScript("circle", "angry");
            var l = angryCircleUtterances.Length;
            var i = Random.Range(0, l);
            if (currentClip.priority < angryCircleUtterances[i].priority)
            {
                audso.Stop();
                audso.PlayOneShot(angryCircleUtterances[i].clip);
                startTime = Time.time;
                currentClip = angryCircleUtterances[i];
                //currentPriority = angryRotationUtterances[i].priority;
            }
        }
        else
        {
            //PlayScript("circle", "happy");
            var l = happyCircleUtterances.Length;
            var i = Random.Range(0, l);
            if (currentClip.priority < happyCircleUtterances[i].priority)
            {
                audso.Stop();
                audso.PlayOneShot(happyCircleUtterances[i].clip);
                startTime = Time.time;
                currentClip = happyCircleUtterances[i];
                //currentPriority = angryRotationUtterances[i].priority;
            }
        }
    }

    public void QEUtterance()
    {
        //calling increment/reset in Fall and Rotate, resetting count after one utterance (might want to change)
        print("Round and round we go!!");
        if (angryChar == true)
        {
            //PlayScript("qe", "angry");
            var l = angryQEUtterances.Length;
            var i = Random.Range(0, l);
            if (currentClip.priority < angryQEUtterances[i].priority)
            {
                audso.Stop();
                audso.PlayOneShot(angryQEUtterances[i].clip);
                startTime = Time.time;
                currentClip = angryQEUtterances[i];
                //currentPriority = angryRotationUtterances[i].priority;
            }
        }
        else
        {

            var l = happyQEUtterances.Length;
            var i = Random.Range(0, l);
            if (currentClip.priority < happyQEUtterances[i].priority)
            {
                audso.Stop();
                audso.PlayOneShot(happyQEUtterances[i].clip);
                startTime = Time.time;
                currentClip = happyQEUtterances[i];
                //currentPriority = angryRotationUtterances[i].priority;
            }
        }
    }

    public void LevelIntroductionUtterance(int sceneIndex)
    {
        print("lv intro!!");
        if (angryChar == true)
        {
            print(sceneIndex);
            if (currentClip.priority < angryLevelIntroUtterances[sceneIndex-1].priority)
            {
                print("intro!!");
                audso.Stop();
                audso.PlayOneShot(angryLevelIntroUtterances[sceneIndex-1].clip);
                startTime = Time.time;
                currentClip = angryLevelIntroUtterances[sceneIndex-1];
            }
        } else
        {
            if (currentClip.priority < happyLevelIntroUtterances[sceneIndex-1].priority)
            {
                print("intro!!");
                audso.Stop();
                audso.PlayOneShot(happyLevelIntroUtterances[sceneIndex-1].clip);
                startTime = Time.time;
                currentClip = happyLevelIntroUtterances[sceneIndex-1];
            }
        }
    }

    public void LevelCompleteUtterance(int sceneIndex)
    {
        //calling increment/reset in Fall and Rotate, resetting count after one utterance (might want to change)
        print("Round and round we go!!");
        if (angryChar == true)
        {
            if (currentClip.priority < angryLevelCompleteUtterances[sceneIndex-1].priority)
            {
                introComplete = false;
                audso.Stop();
                audso.PlayOneShot(angryLevelCompleteUtterances[sceneIndex-1].clip);
                startTime = Time.time;
                currentClip = angryLevelCompleteUtterances[sceneIndex-1];
                //currentPriority = angryLevelCompleteUtterances[sceneIndex].priority;
            }


            //PlayScript("rotations", "angry");
        }
        else
        {
            if (currentClip.priority < happyLevelCompleteUtterances[sceneIndex-1].priority)
            {
                introComplete = false;
                audso.Stop();
                audso.PlayOneShot(happyLevelCompleteUtterances[sceneIndex-1].clip);
                startTime = Time.time;
                currentClip = happyLevelCompleteUtterances[sceneIndex-1];
                //currentPriority = angryLevelCompleteUtterances[sceneIndex].priority;
            }
        }
    }

    public void NotEnoughCoinsUttererance()
    {
        print("you dont have all the coins idiot");

        if (angryChar == true)
        {
            if (finishWithoutCoinToggle == false)
            {
                introComplete = false;
                audso.Stop();
                audso.PlayOneShot(angryFinishWithoutCoinsUtterance.clip);
                startTime = Time.time;
                currentClip = angryFinishWithoutCoinsUtterance;
                finishWithoutCoinToggle = true;
            }
        }
        else
        {
            if (finishWithoutCoinToggle == false)
            {
                introComplete = false;
                audso.Stop();
                audso.PlayOneShot(happyFinishWithoutCoinsUtterance.clip);
                startTime = Time.time;
                currentClip = happyFinishWithoutCoinsUtterance;
                finishWithoutCoinToggle = true;
            }
        }
    }

    public void CoinCollectUttererance()
    {

        if (angryChar == true)
        {
            if (coinWithoutMoveToggle == false)
            {
                print("you got a coint without moving!!");
                introComplete = false;
                audso.Stop();
                audso.PlayOneShot(angryCoinWithoutMoveUtterance.clip);
                startTime = Time.time;
                currentClip = angryCoinWithoutMoveUtterance;
                coinWithoutMoveToggle = true;
            }
        } else
        {
            if (coinWithoutMoveToggle == false)
            {
                print("you got a coint without moving!!");
                introComplete = false;
                audso.Stop();
                audso.PlayOneShot(happyCoinWithoutMoveUtterance.clip);
                startTime = Time.time;
                currentClip = happyCoinWithoutMoveUtterance;
                coinWithoutMoveToggle = true;
            }
        }



    }

    public void MovingPlatformUtterance()
    {
        print("Oh wow the idiot can move a platform");
        if (angryChar == true)
        {
            if (firstMovingPlatformToggle == false)
            {
                print("you got a coint without moving!!");
                introComplete = false;
                audso.Stop();
                audso.PlayOneShot(angryFirstMovingPlatformUtterance.clip);
                startTime = Time.time;
                currentClip = angryFirstMovingPlatformUtterance;
                firstMovingPlatformToggle = true;
            }
        }
        else
        {
            if (firstMovingPlatformToggle == false)
            {
                print("you got a coint without moving!!");
                introComplete = false;
                audso.Stop();
                audso.PlayOneShot(happyFirstMovingPlatformUtterance.clip);
                startTime = Time.time;
                currentClip = happyFirstMovingPlatformUtterance;
                firstMovingPlatformToggle = true;
            }
        }


    }

    public void SidewaysPlatformUtterance()
    {
        //print("SIDEWAYS UTTEREANCASNASCNA");

        if (angryChar == true)
        {
            if (firstSidewaysPlatformToggle == false)
            {
                introComplete = false;
                audso.Stop();
                audso.PlayOneShot(angryFirstSidewaysPlatformUtterance.clip);
                startTime = Time.time;
                currentClip = angryFirstSidewaysPlatformUtterance;
                firstSidewaysPlatformToggle = true;
            }
        }
        else
        {
            if (firstSidewaysPlatformToggle == false)
            {
                introComplete = false;
                audso.Stop();
                audso.PlayOneShot(happyFirstSidewaysPlatformUtterance.clip);
                startTime = Time.time;
                currentClip = happyFirstSidewaysPlatformUtterance;
                firstSidewaysPlatformToggle = true;
            }
        }


    }


    public void RestartUtterance()
    {
        if (angryChar == true)
        {
            PlayScript("restart", "angry");
        }
        else
        {
            PlayScript("restart", "happy");
        }
    }

    public void DeathUtterance()
    {
        if (angryChar == true)
        {
            PlayScript("death", "angry");
        }
        else
        {
            //PlayScript("death", "happy");
            introComplete = false;
            var l = happyDeathUtterances.Length;
            var i = Random.Range(0, l);
            if (currentClip.priority < happyDeathUtterances[i].priority)
            {
                audso.Stop();
                audso.PlayOneShot(happyDeathUtterances[i].clip);
                startTime = Time.time;
                currentClip = happyDeathUtterances[i];
                //currentPriority = angryRotationUtterances[i].priority;
            }
        }
    }

    public void DeathFromWallUtterance()
    {
        print("THat is a wall idiot!!");
        deathByWall = true;
        DeathUtterance();
    }
    public void DeathFromBoundryUtterance()
    {
        deathByBoundry = true;
        print("THat is the boundry idiot!!");
        DeathUtterance();
    }
    public void DeathBySpikesUtterance()
    {
        deathBySpike = true;
        print("THose are spikes idiot!!");
        DeathUtterance();

    }

    public void LevelCompleteUtterance()
    {
        print("the level is done idiot!");
    }
    public void ElapsedTimeUtterance()
    {
        elapsedTime = 20f;
        if (angryChar == true)
        {
            introComplete = false;
            var l = angryElapsedTimeUtterances.Length;
            var i = Random.Range(0, l);
            if (currentClip.priority < angryElapsedTimeUtterances[i].priority)
            {
                audso.Stop();
                audso.PlayOneShot(angryElapsedTimeUtterances[i].clip);
                startTime = Time.time;
                currentClip = angryElapsedTimeUtterances[i];
                //currentPriority = angryRotationUtterances[i].priority;
            }
        }
        else
        {
            //PlayScript("death", "happy");
            introComplete = false;
            var l = happyElapsedTimeUtterances.Length;
            var i = Random.Range(0, l);
            if (currentClip.priority < happyElapsedTimeUtterances[i].priority)
            {
                audso.Stop();
                audso.PlayOneShot(happyElapsedTimeUtterances[i].clip);
                startTime = Time.time;
                currentClip = happyElapsedTimeUtterances[i];
                //currentPriority = angryRotationUtterances[i].priority;
            }
        }
    }
    public void IncrementRotationsBeforeFall()
    {
        rotationsBeforeFall++;
        if (rotationsBeforeFall %  15 == 0)
        {
            RotationsUtterance();
            rotationsBeforeFall = 0;
        }
    }
    public void ResetRotationsBeforeFall()
    {
        rotationsBeforeFall = 0;
    }


    public void ResetPriority()
    {
        //currentPriority = -1;
        currentClip = reset;
        audso.Stop();
    }

    public bool isPlaying()
    {
        if (currentClip.clip != null)
        {
            if ((Time.time - startTime) >= currentClip.clip.length)
            {

                return false;
            }
            else
            {
                return true;

            }
        }
        return false;
    }


    public void ResetElapsedTime()
    {
        elapsedTime = 20f;
    }





    public void IncrementQCount()
    {
        qCount++;
        wCount = 0;
        eCount = 0;
        aCount = 0;
        sCount = 0;
        dCount = 0;
    }
    public void IncrementECount()
    {
        qCount = 0;
        wCount = 0;
        eCount++;
        aCount = 0;
        sCount = 0;
        dCount = 0;
    }
    public void IncrementWCount()
    {
        qCount = 0;
        wCount ++;
        eCount = 0;
        aCount = 0;
        sCount = 0;
        dCount = 0;
    }
    public void IncrementACount()
    {
        qCount = 0;
        wCount = 0;
        eCount = 0;
        aCount++;
        sCount = 0;
        dCount = 0;
    }
    public void IncrementSCount()
    {
        qCount = 0;
        wCount = 0;
        eCount = 0;
        aCount = 0;
        sCount++;
        dCount = 0;
    }
    public void IncrementDCount()
    {
        qCount = 0;
        wCount = 0;
        eCount = 0;
        aCount = 0;
        sCount = 0;
        dCount++;
    }
    public void ResetKeyCounts()
    {
        qCount = 0;
        wCount = 0;
        eCount = 0;
        aCount = 0;
        sCount = 0;
        dCount = 0;
    }

    public void NotQORECount()
    {
        notQECount++;
    }
    public void ResetQECount()
    {
        notQECount = 0;
    }

}
