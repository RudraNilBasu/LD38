using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour {

    [SerializeField]
    GameObject enemyExplosionPrefab, flarePrefab;

    float realSize, expandedSize, t;
    bool isExpanding;

    GameObject thePlayer;

    Rigidbody2D rb;
    float speed = 5.0f;
    bool kill = false;

    private CameraShake cameraShake;

	void Start () {
        cameraShake = CameraShake.instance;
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

        if (!kill)
        {
            float scaled = Mathf.Lerp(realSize, expandedSize, t);
            transform.localScale = new Vector3(scaled, scaled, scaled);

            if (isExpanding)
            {
                t += Time.deltaTime;
            }
            else
            {
                t -= Time.deltaTime;
            }

            if (t <= 0.0f)
            {
                t = 0.0f;
                isExpanding = true;
            }
            else if (t >= 1.0f)
            {
                t = 1.0f;
                isExpanding = false;
            }
        }
        else {
            float scaled = Mathf.Lerp(expandedSize, 0, t);
            transform.localScale = new Vector3(scaled, scaled, scaled);

            t += (1.5f * Time.deltaTime);

            if (t >= 1.0f) {
                cameraShake.Shake(0.2f, 0.5f);
                GameObject _explosion = (GameObject) Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(_explosion, 5.0f);
                Destroy(gameObject);
            }
        }

        //rb.MovePosition(rb.position + rb.velocity + velocity * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {

        // Movement
        float xDiff = thePlayer.transform.position.x - transform.position.x;
        float yDiff = thePlayer.transform.position.y - transform.position.y;

        Vector2 velocity = new Vector2(xDiff, yDiff).normalized;


        rb.MovePosition(rb.position + (velocity + rb.velocity) * speed * Time.deltaTime);
        //rb.velocity = Vector2.ClampMagnitude(rb.velocity, 5.0f);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            PlayerController.Kill();
        }
        else if (coll.tag == "Food")
        {
            Destroy(coll.gameObject);
        }
        else if (coll.tag == "Enemy") {
            cameraShake.Shake(0.1f, 0.1f);
            GameObject _flare = (GameObject)Instantiate(flarePrefab, transform.position, Quaternion.identity);
            Destroy(_flare, 1.0f);
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        kill = true;
    }
}
