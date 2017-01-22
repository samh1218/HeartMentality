using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiled2Unity;

public class CloudGenerator : MonoBehaviour {

    public int MaxClouds;
    public List<GameObject> Clouds = new List<GameObject>();
    public List<GameObject> CloudPrefabs;
    private TiledMap map;

	// Use this for initialization
	void Start () {
        map = gameObject.GetComponent<TiledMap>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.value > 0.98 && Clouds.Count < MaxClouds)
        {
            int index = Random.Range(0, CloudPrefabs.Count);
            GameObject cloud = (GameObject)GameObject.Instantiate(CloudPrefabs[index]);
            int location = Random.Range(0, map.MapHeightInPixels - 1);
            cloud.transform.position = new Vector3(0, location*-1, 0);
            Clouds.Add(cloud);
        }

        foreach(GameObject cld in Clouds)
        {
            if(cld.transform.position.x > map.MapWidthInPixels)
            {
                GameObject removeCloud = cld;
                Clouds.Remove(cld);
                Destroy(removeCloud);
            }

        }
	}
}
