using UnityEngine;
using System.Collections;

public class walls : MonoBehaviour {

    public static int radius = 10;

	// Use this for initialization
	void Start () {
        SetupWalls();
	}

    void SetupWalls()
    {
        radius = LevelManager.currentLevel * 10;
        transform.localScale = new Vector3(radius, radius, radius);
    }
}
