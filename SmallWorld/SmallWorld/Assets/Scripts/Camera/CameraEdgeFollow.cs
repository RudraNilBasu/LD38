using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraEdgeFollow : MonoBehaviour {

    Camera cam;
    float speed = 5.0f;//3, 5

    GameObject thePlayer;

    float boundary = 0.4f;
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
        if (cam != null && thePlayer != null)
        {
            Vector3 viewPos = cam.WorldToViewportPoint(thePlayer.transform.position);
            //print(viewPos.x+","+viewPos.y);
            if (viewPos.x <= boundary)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            else if (viewPos.x >= (1.0f - boundary))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (viewPos.y <= boundary)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
            else if (viewPos.y >= (1.0f - boundary))
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }

        speed = LevelManager.currentLevel > 1 ? 10.0f : 5.0f;
	}
}
