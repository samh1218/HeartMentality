using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class SheepBehavior : MonoBehaviour {

    private BoxCollider2D boxCollider;

    public Vector3 direction = new Vector3(0,1,0);
    public static int baseSpeed = 10;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if it's a pit, kill it
        if (collision.gameObject.tag == "Terrain")
        {
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update () {
        
        Vector3 position = transform.position;
        position = position + direction * (baseSpeed*Time.deltaTime);
        transform.position = position;

    }
}
