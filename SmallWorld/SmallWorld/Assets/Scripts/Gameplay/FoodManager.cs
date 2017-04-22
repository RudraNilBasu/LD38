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
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(5.0f);
            Vector2 initialPosition = Random.insideUnitCircle.normalized * walls.radius;
            Instantiate(foodPrefab, initialPosition, Quaternion.identity);
        }
    }
}
