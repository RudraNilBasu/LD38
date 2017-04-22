using UnityEngine;
using System.Collections;

public class walls : MonoBehaviour {
    /*
    [Header("Wall")]
    [SerializeField]
    GameObject wallPrefab;
    */

    public static int radius = 10;

    float timeLeft = 60.0f;
    
	void Start () {
        SetupWalls();
	}

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if ((int)timeLeft <= 0 && PlayerController.isAlive) {
            LevelManager.currentLevel++;
            SetupWalls();

        }
    }

    void SetupWalls()
    {
        timeLeft = 60.0f;
        radius = LevelManager.currentLevel * 10;
        transform.localScale = new Vector3(radius, radius, radius);
    }
}
