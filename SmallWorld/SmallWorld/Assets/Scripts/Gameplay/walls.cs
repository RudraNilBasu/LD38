using UnityEngine;
using System.Collections;

public class walls : MonoBehaviour {
    /*
    [Header("Wall")]
    [SerializeField]
    GameObject wallPrefab;
    */

    SpriteRenderer img;
    float alpha, t;
    int doOnce = 0;
    public static int radius = 10;

    float totalTime = 60.0f;
    float timeLeft = 60.0f;
    
	void Start () {
        img = GetComponent<SpriteRenderer>();
        SetupWalls();
	}

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if ((int)timeLeft <= 0 && PlayerController.isAlive) {
            LevelManager.currentLevel++;
            SetupWalls();

        }

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
}
