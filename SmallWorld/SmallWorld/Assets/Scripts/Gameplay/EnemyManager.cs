using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    [Header("Enemy")]
    [SerializeField]
    GameObject enemyPrefab;

    int doOnce = 0;

    void Update()
    {
        if (LevelManager.currentLevel > 1 && doOnce == 0) {
            doOnce++;
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        Vector2 initialPosition;
        yield return new WaitForSeconds(10.0f);
        while (PlayerController.isAlive) {
            for (int i = 0; i < LevelManager.currentLevel; i++)
            {
                initialPosition = Random.insideUnitCircle.normalized * walls.radius;
                Instantiate(enemyPrefab, initialPosition, Quaternion.identity);
                yield return new WaitForSeconds(5.0f);
            }
            yield return new WaitForSeconds(10.0f);
        }
    }
}
