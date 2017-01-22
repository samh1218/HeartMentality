using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text sheepSavedCounterDisplay;
    public static int sheepSavedCounter;
    public Text sheepLostCounterDisplay;
    public int sheepLostCounter;

    private Corral corral;

	// Use this for initialization
	void Start () {
        sheepSavedCounterDisplay = GetComponent<Text>();
        sheepLostCounterDisplay = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        sheepSavedCounterDisplay.text = sheepSavedCounter.ToString();
        //sheepLostCounterDisplay.text = sheepLostCounter;
	}
}
