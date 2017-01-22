using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Mine : MonoBehaviour {

    private bool exploding = false;
    public bool Exploding
    {
        get { return exploding; }
        set
        {
            if (value)
                circleCollider.radius = ExplodeRadius;
            else
                circleCollider.radius = SmallRadius;

            exploding = value;
        }
    }
    public int SmallRadius = 6;
    public int ExplodeRadius = 30;

    private CircleCollider2D circleCollider;
    private float explodeTime = 2.0f;
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, circleCollider.radius);
    }

    void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = SmallRadius;
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(exploding)
        {
            explodeTime -= Time.deltaTime;
            if (explodeTime < 0)
                Destroy(this.gameObject);
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(exploding)
        {
            SheepBehavior sb = collision.gameObject.GetComponent<SheepBehavior>();
            if (sb != null)
                sb.Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (exploding)
        {
            SheepBehavior sb = collision.gameObject.GetComponent<SheepBehavior>();
            if (sb != null)
                sb.Explode();
        }
    }
}
