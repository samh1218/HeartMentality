using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZone : MonoBehaviour {

    public Vector3 FlowDirection;
    public int FlowSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SheepBehavior sb = collision.gameObject.GetComponent<SheepBehavior>();
        if(sb)
        {
            sb.BonusSpeed = FlowSpeed;
            sb.BonusDirection = FlowDirection;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SheepBehavior sb = collision.gameObject.GetComponent<SheepBehavior>();
        if (sb)
        {
            if (sb.BonusDirection == FlowDirection)
            { 
                sb.BonusSpeed = 0;
                sb.BonusDirection = Vector3.zero;
            }
        }
    }
}
