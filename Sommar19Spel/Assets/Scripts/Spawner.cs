using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            Spawn();
            timer = spawnRate;
        }
        timer -= Time.deltaTime;
    }

    private void Spawn()
    {
        Instantiate(enemyPrefab, Vector2.zero, Quaternion.identity);
    }

}
