using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour {

    public float speed = .5f;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float randNum = Random.value;
        if (randNum > 0.9)
        {
            rb.velocity = Random.onUnitSphere * speed;
        }
    }
}
