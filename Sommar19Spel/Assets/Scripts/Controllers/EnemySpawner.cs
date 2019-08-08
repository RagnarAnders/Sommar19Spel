using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject startSpawnPosition;
    [SerializeField] private GameObject endSpawnPosition;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        // TO DO: här vill vi göra så att samma event körs flera gånger.
        // spawnEnemy = new SpawnEnemyEvent(enemyPrefab, startSpawnPosition.transform.position.x,
        // endSpawnPosition.transform.position.x, startSpawnPosition.transform.position.y, endSpawnPosition.transform.position.y);

        InvokeRepeating("Spawn", 2f ,spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Spawn()
    {
        SpawnEnemyEvent spawnEnemy = new SpawnEnemyEvent(enemyPrefab, startSpawnPosition.transform.position.x,
        endSpawnPosition.transform.position.x, startSpawnPosition.transform.position.y, endSpawnPosition.transform.position.y);
        spawnEnemy.FireEvent();
    }
}
