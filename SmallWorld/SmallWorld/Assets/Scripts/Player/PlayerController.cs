using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {


    [Header("Energy Release")]
    [SerializeField]
    GameObject energyGO, foodParticles;
    [SerializeField]
    Text timeLeftText;

    [SerializeField]
    GameObject explosionGO;

    private CameraShake cameraShake;
    private AudioManager audioManager;
    private Score score;
    private menu _menu;

    //Vector2 target;
    float speed = 5.0f; // 3, 5

    public static bool isAlive;
    float timeLeft = 30.0f;
    float pickupTime = 6.0f;

    PlayerMotor motor;

    Camera cam;

    public static PlayerController instance;

	void Awake () {
        //instance = this;
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
        isAlive = true;
        //target = transform.position;
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        motor = GetComponent<PlayerMotor>();
	}

    void Start()
    {
        cameraShake = CameraShake.instance;
        score = Score.instance;
        audioManager = AudioManager.instance;
        _menu = menu.instance;
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
                Kill("Out of energy");
            }

            if ((int)timeLeft >= 0) {
                timeLeftText.text = ((int)timeLeft).ToString() + " seconds\nLeft";
            }
            if (timeLeft < 10.0f)
            {
                timeLeftText.color = new Color(1.0f, 0.0f, 0.0f);
            }
            else {
                timeLeftText.color = new Color(1.0f, 1.0f, 1.0f);
            }
            
            // calculate distance from center
            float distance = Vector2.Distance(transform.position, new Vector2(0,0));
            if ((int)distance >= walls.radius) {
                Kill("r.... Roasted");
            }

            float ratio = (distance / walls.radius);
            cam.GetComponent<Bloom>().bloomIntensity = 0.5f + ratio;
            cam.GetComponent<ScreenOverlay>().intensity = 0.5f + ratio;

            speed = LevelManager.currentLevel > 1 ? 10.0f : 5.0f;
        }
	}

    public void Kill(string _value)
    {
        isAlive = false;
        audioManager.PlaySound("player_die");
        Instantiate(explosionGO, transform.position, Quaternion.identity);
        _menu.ShowMenu(_value);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Food") {
            cameraShake.Shake(0.2f, 0.2f);
            audioManager.PlaySound("food");
            timeLeft += pickupTime;
            score.bonusPoint((int)pickupTime);
            score.bonusTime((int)pickupTime);
            energyGO.GetComponent<Animation>().Play();
            Instantiate(foodParticles, transform.position, Quaternion.identity);
            Destroy(coll.gameObject);
        }
    }
}
