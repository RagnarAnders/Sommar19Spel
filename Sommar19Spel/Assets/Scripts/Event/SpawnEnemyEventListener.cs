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
        GameObject enemy = EnemyManager.EnemyManagerRef.GetEnemy(spawn.ObjectToSpawn);
        if (enemy == null)
        {
            Debug.Log("New Enemey");
            GameObject go = Instantiate(spawn.ObjectToSpawn, GetRandomPosition(spawn.StartX, spawn.EndX, spawn.StartY, spawn.EndY), Quaternion.identity);
            EnemyManager.EnemyManagerRef.AddAliveEnemies(go);
        }
        else
        {
            Debug.Log("Old Enemey");
            enemy.transform.position = GetRandomPosition(spawn.StartX, spawn.EndX, spawn.StartY, spawn.EndY);
            enemy.GetComponent<NoDamageTimer>().enabled = true;
            enemy.GetComponent<Enemy>().enabled = false;
            enemy.SetActive(true);
        }
    }
}
