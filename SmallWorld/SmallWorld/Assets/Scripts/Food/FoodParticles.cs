using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EllipsoidParticleEmitter))]
public class FoodParticles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Kill());	
	}

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(2.0f);
        gameObject.GetComponent<EllipsoidParticleEmitter>().emit = false;
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }
}
