using UnityEngine;
using System.Collections;
using Tiled2Unity;

public class GameManager : MonoBehaviour {

    private string startLevel = "test";
    public static TiledMap map = null;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
        //Cursor.lockState = CursorLockMode.Locked;   // keep confined to center of screen
        ///Cursor.lockState = CursorLockMode.None;     // set to default default
        
    }

	// Use this for initialization
	void Start () {
        LoadLevel(startLevel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void LoadLevel(string filename)
    {
        GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/" + filename));
        map = obj.GetComponent<TiledMap>();
    }
}
