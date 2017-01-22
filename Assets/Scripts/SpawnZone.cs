using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : ActorBehavior {

    public List<GameObject> spawnObjectsList = new List<GameObject>();

    public Vector3 location;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < spawnObjectsList.Capacity; i++)
        {
            GameObject obj = (GameObject)spawnObjectsList[i];
            ActorBehavior script = obj ? obj.GetComponent<ActorBehavior>() : null;
            if (script != null)
            {
                Vector3 SpawnLocation = randomizeVector(location, 0, 10, true, i);
                Vector3 SpawnDirection = randomizeVector(direction, 0, 0.2f, true, i);
                script.SpawnActor(obj.name, SpawnDirection, SpawnLocation);
            }
        }
    }

    Vector3 randomizeVector(Vector3 vector, float min, float max, bool randNegOrPos = false, int multiplier = 1)
    {
        // Spawn Displacement
        float x = randomFloat(min, max, randNegOrPos, multiplier);
        float y = randomFloat(min, max, randNegOrPos, multiplier);
        return vector + new Vector3(x, y);
    }

    float randomFloat(float min, float max, bool randNegOrPos = false, int multiplier = 1)
    {
        int SignMultiplier = 1; // has no effect
        if (randNegOrPos) // randomize if num should be neg or pos...
        {
            if (Random.value < 0.5f)
            {
                SignMultiplier = -1;
            }
        }
        return SignMultiplier * multiplier * Random.Range(min, max);
    }
}
