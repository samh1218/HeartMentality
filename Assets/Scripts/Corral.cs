using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corral : MonoBehaviour {

    public int SheepCount = 0;
    private LevelManager lm = new LevelManager();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<SheepBehavior>() != null)
        {
            Destroy(collision.gameObject);
            SheepCount++;
            UI.sheepSavedCounter = SheepCount;
        }
    }
}
