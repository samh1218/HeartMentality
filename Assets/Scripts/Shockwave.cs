using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour {

    public float sizeIncrease;
    public float lifetime;
    public Color color;
    //   Material material;

    float life;
    Vector3 startScale;
    SpriteRenderer renderer;


    // Use this for initialization
    void Start () {
        life = lifetime;
        startScale = transform.localScale;
        renderer = GetComponent<SpriteRenderer>();
        color = renderer.color;
    }
	
	// Update is called once per frame

	void Update () {
		if (life <= 0)
        {
            Destroy(transform.gameObject);
        }

        renderer.transform.localScale = startScale + sizeIncrease * (lifetime - life) / lifetime * Vector3.one;
        color.a = life / lifetime;
        renderer.color = color;

        life -= Time.deltaTime *2;
	}

}


// BACK UP CODE :
// in START :
//        material = GetComponent<MeshRenderer>().material;
//        material.color = color;
//        GetComponent<Renderer>().enabled = true;

// in UPDATE :
//        transform.localScale = startScale + sizeIncrease * (lifetime - life) / lifetime * Vector3.one;
//        Color newcolor = material.color;
//        newcolor.a = life / lifetime;
//        material.color = newcolor;