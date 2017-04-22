using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraEdgeFollow : MonoBehaviour {

    Camera cam;
    float speed = 5.0f;//3

    GameObject thePlayer;
    /*
    int boundary = 50;
    float screenWidth, screenHeight;
    */

	void Start () {
        cam = GetComponent<Camera>();
        thePlayer = GameObject.Find("Player");
        if (thePlayer == null) {
            Debug.LogError("ERROR: No Player found");
        }
        /*
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        */
	}
	

	void Update () {
        /*
        float xPos = thePlayer.transform.position.x;
        float yPos = thePlayer.transform.position.y;
        if (xPos > screenWidth) { }
        */
        Vector3 viewPos = cam.WorldToViewportPoint(thePlayer.transform.position);
        //print(viewPos.x+","+viewPos.y);
        if (viewPos.x <= 0.2)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (viewPos.x >= 0.8) {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (viewPos.y <= 0.2)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else if (viewPos.y >= 0.8) {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
	}
}
