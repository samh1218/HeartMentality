using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
        vertExtent = camera.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
    }

    private int Boundary  = 50;
    private int speed  = 200;
    

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
        get { return (float)(GameManager.map.MapWidthInPixels - horzExtent); }
    }
    private float minY
    {
        get { return (float)(-GameManager.map.MapHeightInPixels - vertExtent); }
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
        if (horzExtent < GameManager.map.MapWidthInPixels)
            v3.x = Mathf.Clamp(v3.x, minX, maxX);
        else
            v3.x = GameManager.map.MapWidthInPixels / 2;

        if (vertExtent < GameManager.map.MapHeightInPixels)
            v3.y = Mathf.Clamp(v3.y, minY, maxY);
        else
            v3.x = GameManager.map.MapHeightInPixels / 2;

        transform.position = v3;
    }
}
