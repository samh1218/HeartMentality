using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tiled2Unity;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public List<GameObject> localLevels = new List<GameObject>();
    public static List<GameObject> levels = new List<GameObject>();
    public static int numOfSheepDestroyed = 0;
    public static TiledMap currentMap;
    public static int currentLevelIndex;

    private static GameObject currentLevel;

    public static AudioSource source;
    public static AudioListener listener;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
        //Cursor.lockState = CursorLockMode.Locked;   // keep confined to center of screen
        ///Cursor.lockState = CursorLockMode.None;     // set to default default
        
    }

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
        // Copy Levels to Static List
        CopyLevels();
        if (levels.Capacity != 0)
        {
            LoadLevel(levels[0]);
            currentLevelIndex = 0;
        }
    }

    // Update is called once per frame
    void Update () {
=======
        LoadLevel(startLevel);
        listener = GetComponent<AudioListener>();
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
>>>>>>> 2bafa5a068d5204607ca462fd1b02a890aa68636
	
	}

    private void CopyLevels()
    {
        levels.Clear();
        for (int i = 0; i < localLevels.Capacity; i++)
        {
            levels.Add(localLevels[i]);
        }
        localLevels.Clear();
    }

    private static void LoadLevel(GameObject level)
    {
        if (level.GetComponent<TiledMap>() == null)
        {
            Debug.Log("Attempted to load a null or a non-level object.");
            return;
        }

        currentLevel = GameObject.Instantiate(level);
        currentMap = currentLevel.GetComponent<TiledMap>();
//        map = obj.GetComponent<TiledMap>();
    }

    private static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadNextLevel()
    {
        int nextLevelIndex = currentLevelIndex + 1;
        if (nextLevelIndex != levels.Capacity)
        {
            numOfSheepDestroyed = 0;
            Destroy(currentLevel);
            LoadLevel(levels[nextLevelIndex]);
            currentLevelIndex = nextLevelIndex;
        }
    }
    public static void RestartCurrentLevel()
    {
        numOfSheepDestroyed = 0;
        Destroy(currentLevel);
        LoadLevel(levels[currentLevelIndex]);
    }
}
