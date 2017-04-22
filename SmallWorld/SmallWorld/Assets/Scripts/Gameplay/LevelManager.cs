using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public static int currentLevel;

    void Awake()
    {
        currentLevel = 1;
    }
}
