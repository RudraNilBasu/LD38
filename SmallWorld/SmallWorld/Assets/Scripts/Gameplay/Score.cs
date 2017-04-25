using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [Header("UI Elements")]
    [SerializeField]
    Text score, bonusScoreText, bonusTimeText;

    public static Score instance;

    int currentScore;
    float time;
    int extra;
    
    void Awake() {
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
        if (PlayerController.isAlive)
        {
            time += Time.deltaTime;
            currentScore = (((int)time) + extra);
            score.text = currentScore.ToString();
        }
	}

    public void bonusPoint(int _value)
    {
        extra += _value;
        bonusScoreText.text = "+" + _value;
        bonusScoreText.GetComponent<Animation>().Play();
    }

    public void bonusTime(int _value)
    {
        bonusTimeText.text = "+" + _value + " sec";
        bonusTimeText.GetComponent<Animation>().Play();
    }

    public int getCurrentScore()
    {
        return currentScore;
    }
}
