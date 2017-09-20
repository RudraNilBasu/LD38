using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    [SerializeField]
    GameObject shootpoints, bullets;

	// Use this for initialization
	void Start () {
        StartCoroutine(shoot());
	}

    void Update()
    {
        //transform.Rotate(Vector2.up, Space.World);
        transform.Rotate(0, 0, 10.0f * Time.deltaTime);
    }

    IEnumerator shoot()
    {
        while (PlayerController.isAlive) {
            yield return new WaitForSeconds(2.0f);
            foreach (Transform child in shootpoints.transform)
            {
                Instantiate(bullets, child.position, child.rotation, child);
            }
        }
    }
}
