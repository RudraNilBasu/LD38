using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class bullet : MonoBehaviour {

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        
        //rb.velocity = new Vector2(10.0f, 0.0f);
        
        Vector2 localVel = transform.InverseTransformDirection(rb.velocity);
        localVel.x = 10.0f;
        rb.velocity = transform.TransformDirection(localVel);
        //rb.velocity = transform.right * 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
        //rb.velocity = transform.right * 10.0f;
    }
}
