using UnityEngine;
using System.Collections;

public class walls : MonoBehaviour {

    public static int radius = 10;

    float timeLeft = 60.0f;
    
	void Start () {
        SetupWalls();
	}

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if ((int)timeLeft <= 0 && PlayerController.isAlive) {
            print("Level Won!!");
        }
    }

    void SetupWalls()
    {
        radius = LevelManager.currentLevel * 10;
        transform.localScale = new Vector3(radius, radius, radius);
    }
}
