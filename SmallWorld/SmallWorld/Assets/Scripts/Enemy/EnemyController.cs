using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour {

    float realSize, expandedSize, t;
    bool isExpanding;

    GameObject thePlayer;

    Rigidbody2D rb;
    float speed = 2.0f;

	void Start () {
        isExpanding = false;
        t = 0;
        realSize = 1.0f;
        expandedSize = 1.5f;

        thePlayer = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // Animation part
        float scaled = Mathf.Lerp(realSize, expandedSize, t);
        transform.localScale = new Vector3(scaled, scaled, scaled);
        
        if(isExpanding)
        {
            t += Time.deltaTime;
        } else
        {
            t -= Time.deltaTime;
        }

        if(t <= 0.0f)
        {
            t = 0.0f;
            isExpanding = true;
        } else if(t >= 1.0f)
        {
            t = 1.0f;
            isExpanding = false;
        }

        // Movement
        float xDiff = thePlayer.transform.position.x - transform.position.x;
        float yDiff = thePlayer.transform.position.y - transform.position.y;

        Vector2 velocity = new Vector2(xDiff, yDiff).normalized;

        
        rb.MovePosition(rb.position + rb.velocity + velocity * speed * Time.deltaTime);
    }
}