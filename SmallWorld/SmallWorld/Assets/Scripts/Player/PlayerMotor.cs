using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour {

    Rigidbody2D rb;
    Vector2 velocity;
    
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        PerformMovement();
	}

    public void Move(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    void PerformMovement()
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
}
