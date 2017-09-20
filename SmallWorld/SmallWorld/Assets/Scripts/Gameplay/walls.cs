using UnityEngine;
using System.Collections;

public class walls : MonoBehaviour {
    /*
    [Header("Wall")]
    [SerializeField]
    GameObject wallPrefab;
    */

    [SerializeField]
    GameObject wallExplode;
    SpriteRenderer img;
    float alpha, t;
    int doOnce = 0;
    public static int radius = 10;

    float totalTime = 60.0f;
    float timeLeft = 60.0f;

    CameraEffects cam;
    AudioManager audioManager;
    Story story;

    int storyOnce = 0;

	void Start () {
        cam = CameraEffects.instance;
        audioManager = AudioManager.instance;
        story = Story.instance;
        img = GetComponent<SpriteRenderer>();
        SetupWalls();
        //StartCoroutine(TellStory1());
	}

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if ((int)timeLeft == 3) {
            cam.chromatic_vignette();
        }

        if ((int)timeLeft == 9)
        {
            cam.chromatic_vignette();
        }

        if ((int)timeLeft <= 0 && PlayerController.isAlive) {
            Vector2 pos;
            for (int i = 0; i < radius; i++) {
                pos = Random.insideUnitCircle * radius;
                Instantiate(wallExplode, pos, Quaternion.identity);
            }
            audioManager.PlaySound("explosion_2");
            LevelManager.currentLevel++;
            SetupWalls();

            if (LevelManager.currentLevel == 2 && storyOnce == 0) {
                //StartCoroutine(TellStory2());
            }
        }

        /*
        float ratio = timeLeft / totalTime;
        if (ratio < 0.2f && ratio > 0.1f && doOnce == 0) {
            //img.color = new Color(img.color.r, img.color.g, img.color.b, 0.2f);
            doOnce++;
            alpha = 0.2f;
            t = 0.0f;
        } else if( ratio <= 0.1f && doOnce == 1)
        {
            //img.color = new Color(img.color.r, img.color.g, img.color.b, 0.1f);
            doOnce++;
            alpha = 0.1f;
            t = 0.0f;
        }

        img.color = new Color(img.color.r, img.color.g, img.color.b, Mathf.Lerp(img.color.a, alpha, t));
        t += Time.deltaTime;
        */
    }

    void SetupWalls()
    {
        doOnce = 0;
        alpha = 1.0f;
        t = 0.0f;
        timeLeft = totalTime;
        radius = LevelManager.currentLevel * 10;
        transform.localScale = new Vector3(radius, radius, radius);
    }

    IEnumerator TellStory1()
    {
        yield return new WaitForSeconds(2.0f);
        if (!PlayerController.isAlive)
        {
            yield return 0;
        }
        story.Show("This is your world");
        yield return new WaitForSeconds(4.0f);

        if (!PlayerController.isAlive)
        {
            yield return 0;
        }
        story.Show("Absorb the smaller particles in your world to make sure you do not run out of energy");
    }

    IEnumerator TellStory2()
    {
        yield return new WaitForSeconds(3.0f);

        if (!PlayerController.isAlive) {
            yield return 0;
        }
        story.Show("But... this world may not be yours");
        yield return new WaitForSeconds(5.0f);

        if (!PlayerController.isAlive)
        {
            yield return 0;
        }

        story.Show("You see, the world is just too small to hold every one");
        yield return new WaitForSeconds(5.0f);

        if (!PlayerController.isAlive)
        {
            yield return 0;
        }
        story.Show("Hunt, or be hunted");
    }
}
