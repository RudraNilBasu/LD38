using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    //Vector2 target;
    float speed = 3.0f;

    public static bool isAlive;
    float timeLeft = 30.0f;
    float pickupTime = 10.0f;

    PlayerMotor motor;

	void Start () {
        isAlive = true;
        //target = transform.position;

        motor = GetComponent<PlayerMotor>();
	}
	
	void Update () {
        if (isAlive)
        {
            // Movement
            /*
            if (Input.GetMouseButtonDown(0))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            */
            float _xMov = Input.GetAxis("Horizontal");
            float _yMov = Input.GetAxis("Vertical");

            Vector2 _horizontalVelocity = transform.right * _xMov; //red
            Vector2 _verticalVelocity = transform.up * _yMov; // green

            Vector2 velocity = (_horizontalVelocity + _verticalVelocity) * speed;

            motor.Move(velocity);

            // remaining time
            timeLeft -= Time.deltaTime;
            if ((int)timeLeft <= 0) {
                Kill();
            }

            // calculate distance from center
            float distance = Vector2.Distance(transform.position, new Vector2(0,0));
            if ((int)distance >= walls.radius) {
                Kill();
            }
        }
	}

    void Kill()
    {
        isAlive = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy") {
            timeLeft += pickupTime;
            Destroy(coll.gameObject);
        }
    }
}
