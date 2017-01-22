﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
        vertExtent = camera.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
    }

    private int Boundary  = 75;
    private int speed  = 400;
    

    Camera camera;
    private float vertExtent;
    private float horzExtent;
    private float minX
    {
        get { return (float)(horzExtent); }
        //get { return (float)(horzExtent/ 2.0); }
    }
    private float maxX
    {
        //get { return (float)(GameManager.map.MapWidthInPixels - horzExtent / 2.0); }
        get { return (float)(GameManager.currentMap.MapWidthInPixels - horzExtent); }
    }
    private float minY
    {
        get { return (float)(-GameManager.currentMap.MapHeightInPixels - vertExtent); }
        //get { return (float)(vertExtent / 2.0); }
    }
    private float maxY
    {
        get { return (float)(-vertExtent); }
        //get { return (float)(GameManager.map.MapHeightInPixels - vertExtent / 2.0); }
    }

    /*
         minX = horzExtent - mapX / 2.0;
         maxX = mapX / 2.0 - horzExtent;
         minY = vertExtent - mapY / 2.0;
         maxY = mapY / 2.0 - vertExtent;
     */

    private void OnDrawGizmos()
    {
        //The current screen boundary
        Gizmos.color = new Color(1, 1, 1, 0.3f);
        Gizmos.DrawCube(transform.position, new Vector3(1,1,0));
    }

    // Update is called once per frame
    void Update () {

        //Spawn waves on click
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 point = ray.origin + (ray.direction * 10);
            point.z = 0;
            GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/" + "wave"));
            obj.transform.position = point;
        }

        //Move the camera around the level bounds
        Vector3 position = transform.position;
        if (Input.mousePosition.x > Screen.width - Boundary)
        {
            position.x += speed * Time.deltaTime;
        }

        if (Input.mousePosition.x < Boundary)
        {
            position.x -= speed * Time.deltaTime;
        }

        if (Input.mousePosition.y > Screen.height - Boundary)
        {
            position.y += speed * Time.deltaTime;
        }

        if (Input.mousePosition.y < Boundary)
        {
            position.y -= speed * Time.deltaTime;
        }

        transform.position = position;
    }

    void LateUpdate()
    {
        var v3 = transform.position;
        if (horzExtent < GameManager.currentMap.MapWidthInPixels)
            v3.x = Mathf.Clamp(v3.x, minX, maxX);
        else
            v3.x = GameManager.currentMap.MapWidthInPixels / 2;

        if (vertExtent < GameManager.currentMap.MapHeightInPixels)
            v3.y = Mathf.Clamp(v3.y, minY, maxY);
        else
            v3.x = GameManager.currentMap.MapHeightInPixels / 2;

        transform.position = v3;
    }
}
