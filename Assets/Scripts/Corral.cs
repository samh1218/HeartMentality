﻿using System.Collections;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<SheepBehavior>() != null)
        {
            Destroy(collision.gameObject);
            SheepCount++;
            Debug.Log(SheepCount.ToString());
        }
    }
}
