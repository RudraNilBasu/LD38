using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class prizm : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(playAnimation());
	}

    IEnumerator playAnimation()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Playing");
        gameObject.GetComponent<Animation>().Play("prizm_logo");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("loader");
    }
}
