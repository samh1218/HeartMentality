using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corral : MonoBehaviour {

    public int SheepCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<SheepBehavior>() != null)
        {
            Destroy(collision.gameObject);
            SheepCount++;
<<<<<<< HEAD
            Debug.Log(SheepCount.ToString());
=======
            UI.sheepSavedCounter = SheepCount;
>>>>>>> 2bafa5a068d5204607ca462fd1b02a890aa68636
        }
    }
}
