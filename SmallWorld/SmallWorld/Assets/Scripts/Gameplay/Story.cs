using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Story : MonoBehaviour {

    public static Story instance;

    [SerializeField]
    GameObject bkg;
    [SerializeField]
    Text text;

    bool showing = false;

	void Awake () {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }

        bkg.SetActive(false);
	}

    void Update()
    {
        if (showing && Input.GetKeyDown(KeyCode.Space)) {
            showing = false;
            //bkg.GetComponent<Animation>().Play("story_off");
            bkg.SetActive(false);
        }

        /*
        if owi(!shng && Input.GetKeyDown(KeyCode.T)) {
            Show("testing");
        }
        */
    }

    public void Show(string msg)
    {
        bkg.SetActive(true);
        //bkg.GetComponent<Animation>().Play("story_off");
        showing = true;
        text.text = msg;
    }
}
