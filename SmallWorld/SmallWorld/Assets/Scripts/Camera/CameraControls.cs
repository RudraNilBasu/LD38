using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraControls : MonoBehaviour {

    Camera cam;
    float t = 0;

    //int doOnce = 0;
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	void Update () {
        // Initial camera animation
        cam.orthographicSize = Mathf.Lerp(0, 10, t);

        t += 0.5f * Time.deltaTime;

        /*
        if (LevelManager.currentLevel >= 2 && doOnce == 0) {
            doOnce++;
            StartCoroutine(FollowPlayer());
        }
        */
	}

    /*
    IEnumerator FollowPlayer()
    {
        yield return new WaitForSeconds(2.0f);
        cam.GetComponent<SmoothFollow>().enabled = true;
    }
    */
}
