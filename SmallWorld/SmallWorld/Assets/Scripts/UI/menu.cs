using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    [SerializeField]
    GameObject gameScore, gameTime, menuHead, menuScore, retry, mainMenu, panel, bkg;

    public static menu instance;

    private Score score;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }

    void Start()
    {
        score = Score.instance;

        menuHead.SetActive(false);
        menuScore.SetActive(false);
        retry.SetActive(false);
        mainMenu.SetActive(false);
        panel.SetActive(false);
    }

    public void ShowMenu(string reason)
    {
        StartCoroutine(Perform(reason));
    }

    IEnumerator Perform(string reason)
    {
        yield return new WaitForSeconds(0.5f);

        gameScore.SetActive(false);
        gameTime.SetActive(false);
        bkg.SetActive(false);

        panel.SetActive(true);

        menuHead.GetComponent<Text>().text = reason;
        menuHead.SetActive(true);
        menuHead.GetComponent<Animation>().Play();

        menuScore.GetComponent<Text>().text = "Score: " + score.getCurrentScore().ToString();
        menuScore.SetActive(true);
        menuScore.GetComponent<Animation>().Play();

        retry.SetActive(true);
        retry.GetComponent<Animation>().Play();

        mainMenu.SetActive(true);
        mainMenu.GetComponent<Animation>().Play();
    }

    public void btn_retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void btn_menu()
    {
        SceneManager.LoadScene("menu");
    }
}
