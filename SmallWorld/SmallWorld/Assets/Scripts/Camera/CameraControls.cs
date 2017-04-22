using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraControls : MonoBehaviour {

    Camera cam;

    float t = 0;
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	void Update () {
        // Initial camera animation
        cam.orthographicSize = Mathf.Lerp(0, 10, t);

        t += 0.5f * Time.deltaTime;
	}
}
