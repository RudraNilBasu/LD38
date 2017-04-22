using UnityEngine;
using System.Collections;

public class FoodManager : MonoBehaviour {

    [Header("Food Properties")]

    [SerializeField]
    GameObject foodPrefab;
    	
	// Use this for initialization
	void Start () {
        StartCoroutine(GenerateRandomFood());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator GenerateRandomFood()
    {
        yield return new WaitForSeconds(10.0f);
        /*
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(10.0f);
            Vector2 initialPosition = Random.insideUnitCircle.normalized * walls.radius;
            Instantiate(foodPrefab, initialPosition, Quaternion.identity);
            initialPosition = Random.insideUnitCircle.normalized * walls.radius;
            Instantiate(foodPrefab, initialPosition, Quaternion.identity);
        }
        */
        while (PlayerController.isAlive) {
            yield return new WaitForSeconds(10.0f);
            Vector2 initialPosition = Random.insideUnitCircle.normalized * walls.radius;
            Instantiate(foodPrefab, initialPosition, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
            initialPosition = Random.insideUnitCircle.normalized * walls.radius;
            Instantiate(foodPrefab, initialPosition, Quaternion.identity);
        }
    }
}
