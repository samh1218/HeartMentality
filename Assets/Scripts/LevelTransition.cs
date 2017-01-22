using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  LevelTransition deals with all the conditions
 *  and the actual transition from one level to another.
 *  
 *  For example, this class stores the 'victory'
 *  conditions or the 'losing' conditions
 *  of the level.
 *  
 * If victory conditions has been met,
 * then the level transitions to the next level
 * 
 */

public class LevelTransition : MonoBehaviour {

    public int SheepNumToVictory;

    public GameObject corral;
    public GameObject spawn;

    // Use this for initialization
    void Start() {

    }

    void Update()
    {
        if (isAllSheepDestroyed() || isVictoryAchieved())
        {
            LoadNextLevel();
        }
    }

    bool isVictoryAchieved() {
        if (corral.GetComponent<Corral>().SheepCount >= SheepNumToVictory)
            return true;
        return false;
    }

    bool isAllSheepDestroyed()
    {
        Debug.Log(GameManager.numOfSheepDestroyed.ToString());
        if (GameManager.numOfSheepDestroyed == spawn.GetComponent<SpawnZone>().spawnObjectsList.Capacity)
            return true;
        return false;
    }

    void LoadNextLevel()
    {
        Debug.Log("LoadNextLevel");
        if (isVictoryAchieved())
        {
            GameManager.LoadNextLevel();
        }
        else
        {
            GameManager.RestartCurrentLevel();
        }
    }
}
