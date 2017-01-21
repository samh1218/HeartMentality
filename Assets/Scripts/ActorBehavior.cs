using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBehavior : MonoBehaviour {

    public Vector3 direction;
    // Use this for initialization
    void Start()
    {

    }

    public virtual void SpawnActor(string actorFileName, Vector3 moveDirection, Vector3 spawnLocation)
    {
        GameObject obj = SpawnActor(actorFileName);
        direction = moveDirection;
        obj.transform.position = spawnLocation;
        //        Debug.Log(obj.transform.position.ToString());
    }

    private GameObject SpawnActor(string actorFileName)
    {
        GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/" + actorFileName));
        return obj;
    }
}
