using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class SheepBehavior : ActorBehavior {

    private BoxCollider2D boxCollider;
    public static int baseSpeed = 10;
    public Vector3 BonusDirection = Vector3.zero;
    public int BonusSpeed = 0;
    private Animator animator;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

    }

    public void Explode()
    {
        GameManager.numOfSheepDestroyed++;
        Destroy(this.gameObject);
    }

    public void FallToDeath()
    {
        GameManager.numOfSheepDestroyed++;
        GameManager.source.clip = Resources.Load("Sound/WhenKilled/Mehh01") as AudioClip;
        GameManager.source.Play();
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if it's a pit, kill it
        if (collision.gameObject.tag == "Terrain")
        {
            FallToDeath();
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //If we hit a wave, push the sheep
        Wave wave = other.gameObject.GetComponent<Wave>();
        if (wave != null)
        {
            Vector3 pushDirection = transform.position - wave.transform.position;
            transform.position = wave.transform.position + pushDirection.normalized * (float)(wave.circleCollider.radius);
            direction = Vector3.Lerp(direction, pushDirection, Time.deltaTime/2);
        }

        Mine mine = other.gameObject.GetComponent<Mine>();
        if(mine != null)
        {
            mine.Exploding = true;
        }
    }

    // Update is called once per frame
    void Update () {
        
        Vector3 position = transform.position;
        position = position + direction * (baseSpeed*Time.deltaTime) + BonusDirection*(BonusSpeed*Time.deltaTime);
        transform.position = position;

        Vector3 velocity = direction * (baseSpeed * Time.deltaTime) + BonusDirection * (BonusSpeed * Time.deltaTime);
        velocity = velocity.normalized;
        animator.SetFloat("VelocityX", velocity.x);

        animator.SetFloat("VelocityY", velocity.y);

    }

    public override void SpawnActor(string actorFileName, Vector3 moveDirection, Vector3 location)
    {
        base.SpawnActor(actorFileName, moveDirection, location);
    }
}
