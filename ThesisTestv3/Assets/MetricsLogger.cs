using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MetricsLogger : MonoBehaviour {

    private static MetricsLogger _instance;
    private static object _lock = new object();

    private static bool applicationIsQuitting = false;

    public static MetricsLogger Instance {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning("MetricsLogger already destroyed on application quit.");
                return null;
            }
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<MetricsLogger>();
                    if (FindObjectsOfType<MetricsLogger>().Length > 1)
                    {
                        Debug.LogError("Trouble: found duplicate MetricsLogger that didn't destroy itself.");
                        return _instance;
                    }
                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<MetricsLogger>();
                        singleton.name = "Metrics Logger";
                        DontDestroyOnLoad(singleton);
                        Debug.Log("Created Metrics Logger object dynamically.");
                    }
                }
                return _instance;
            }
        }
    }

    void Awake()
    {
        if (_instance == null)
        { // gameobject was created in editor
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (_instance != this)
        { // duplicate gameobject not needed
            DestroyImmediate(this.gameObject);
        }
    }

    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }

    // instance members and methods below:

    private List<string> directFirst = new List<string> { "MainMenu", "Direct Tutorial", "Direct MainGame", "Non-Direct MainGame" };
    private List<string> nondirectFirst = new List<string> { "MainMenu", "Direct Tutorial", "Non-Direct MainGame", "Direct MainGame" };
    public List<string> scenesList = new List<string> { "Direct TestingScene" };
    private const float updateInterval = 1f;
    public string currentScene;
    public string PlayerID;

    public void switchToDirectFirst()
    {
        scenesList = directFirst;
    }
    public void switchToNonDirectFirst()
    {
        scenesList = nondirectFirst;
    }
    public void LoadNextScene()
    {
        scenesList.RemoveAt(0);
        if (scenesList.Count == 0)
        {
            Application.Quit();
        }
        SceneManager.LoadScene(scenesList[0].Split()[1]);
    }
    public string getCurrentSceneType()
    {
        return scenesList[0].Split()[0];
    }
    public bool NonDirect
    {
        get { return (getCurrentSceneType() == "Non-Direct"); }
    }

    private string _randomID = null;

    public string RandomID
    { // to identify the subject
        get
        {
            if (_randomID == null)
            {
                System.TimeSpan ts = (System.DateTime.UtcNow - new System.DateTime(1970, 1, 1));
                int timestamp = (int)ts.TotalSeconds;
               // _randomID = Random.Range(0, 10000).ToString("0000") + timestamp.ToString().Substring(4);
                Debug.Log("Created random ID: " + _randomID);
                _randomID = System.DateTime.Now.ToString("yyyy_MM_dd_hh.mm.ss");
            }
            return _randomID;
        }
    }
    const string METRICS_DIR = "Metrics/";
    private string destinationFilename
    {
        get { return METRICS_DIR + "Log." + RandomID + ".txt"; }
    }

    void Start()
    {
        System.IO.Directory.CreateDirectory(METRICS_DIR);
        LogData("Started game for subject " + RandomID, true);
    }

    public void LogData(string dataLine, bool unitylog)
    {
        dataLine = System.DateTime.Now.ToString("u") + ", " + dataLine + " ";
        File.AppendAllText(destinationFilename, dataLine + "\r\n");
        if (unitylog)
        {
            Debug.Log(dataLine);
        }
    }
    void Update()
    {
        if (scenesList.Count > 0)
        {
            currentScene = getCurrentSceneType();
        }
        PlayerID = RandomID;

    }
}
