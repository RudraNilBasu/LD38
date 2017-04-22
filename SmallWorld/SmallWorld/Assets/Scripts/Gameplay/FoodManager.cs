using UnityEngine;
using System.Collections;

public class FoodManager : MonoBehaviour {

    [Header("Food Properties")]

    [SerializeField]
    GameObject foodPrefab;
    	
	// Use this for initialization
	void Start () {
        GenerateRandomFood();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GenerateRandomFood()
    {
        Vector2 initialPosition = Random.insideUnitCircle.normalized * walls.radius;
        Instantiate(foodPrefab, initialPosition, Quaternion.identity);
    }
}
