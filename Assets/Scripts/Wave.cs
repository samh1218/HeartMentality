using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Wave : MonoBehaviour {

    public CircleCollider2D circleCollider;
    private ParticleSystem pSystem;

    public int expandSpeed = 80;


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, circleCollider.radius);
    }

    // Use this for initialization
    void Start () {
        circleCollider = GetComponent<CircleCollider2D>();
        pSystem = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        circleCollider.radius += Time.deltaTime * expandSpeed;

        if(pSystem)
        {
            if (!pSystem.IsAlive())
            {
                Destroy(gameObject);
            }
        }
	}
}
