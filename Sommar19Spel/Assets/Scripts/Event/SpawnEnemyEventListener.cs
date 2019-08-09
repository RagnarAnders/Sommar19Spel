using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyEventListener : SpawnEventListener
{
    Dictionary<Enemy, GameObject> enemyList;

    protected override void OnEvent(SpawnEvent spawn)
    {
        spawnObject = spawn.ObjectToSpawn;
        if (!spawnObject.GetComponent<Enemy>())
        {
            return;
        }
        GameObject enemy = EnemyManager.EnemyManagerRef.GetEnemy();
        if (enemy == null)
        {
            GameObject go = Instantiate(spawn.ObjectToSpawn, getRandomPosition(spawn.StartX, spawn.EndX, spawn.StartY, spawn.EndY), Quaternion.identity);
        }
        else
        {
            enemy.transform.position = getRandomPosition(spawn.StartX, spawn.EndX, spawn.StartY, spawn.EndY);
            enemy.GetComponent<NoDamageTimer>().enabled = true;
            enemy.GetComponent<Enemy>().enabled = false;
            enemy.SetActive(true);
        }

    }
}
