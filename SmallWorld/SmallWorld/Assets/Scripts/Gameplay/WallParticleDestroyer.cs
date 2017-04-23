using UnityEngine;
using System.Collections;

public class WallParticleDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Kill());
	}

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
