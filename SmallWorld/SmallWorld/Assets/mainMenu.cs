using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    [SerializeField]
    Image loadingBar;
    [SerializeField]
    Text loadingText;

    float loadingProgress;

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "loader") {
            StartCoroutine(LoadAsynchronously("menu"));
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "menu") {
            gameObject.GetComponent<Animation>().Play("cameraMenuBloomIntensity");
            gameObject.GetComponent<Animation>().Play("cameraZoomInMenu");
            //gameObject.GetComponent<Animation>().Play("cameraMenuBloomIntensity");
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(startGame());
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            Application.Quit();
        }

        if (SceneManager.GetActiveScene().name == "loader") {
            loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, loadingProgress, Time.deltaTime * 10f);
        }
	}

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("MainLevel");
    }

    IEnumerator LoadAsynchronously(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        loadingProgress = 0.0f;
        loadingBar.fillAmount = 0.0f;

        while (!operation.isDone) {
            loadingProgress = Mathf.Clamp01(operation.progress / 0.9f);
            //float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, progress, Time.deltaTime * 10f);//progress;
            loadingText.text = (loadingProgress * 100) + "/.\nLoading";
            yield return null;
        }
    }
}
