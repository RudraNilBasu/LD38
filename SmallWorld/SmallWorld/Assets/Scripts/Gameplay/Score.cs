using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField]
    Text score;

    public static Score instance;

    int currentScore;
    float time;
    int extra;
    
    void Start() {
        currentScore = 0;
        time = 0;
        extra = 0;

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        currentScore = (((int)time) + extra);
        score.text = currentScore.ToString();
	}

    public void bonus(int _value)
    {
        extra += _value;
    }
}
