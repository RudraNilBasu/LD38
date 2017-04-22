using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
    
    Vector2 finalPosition;
    float speed = 1.2f;

    void Start () {
        finalPosition = Random.insideUnitCircle * walls.radius;
	}
	
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, finalPosition, speed * Time.deltaTime);
    }
}
