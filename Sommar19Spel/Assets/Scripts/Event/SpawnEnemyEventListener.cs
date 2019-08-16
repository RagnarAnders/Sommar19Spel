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
        GameObject enemy = EnemyManager.EnemyManagerRef.GetObject(spawn.ObjectToSpawn);
        if (enemy == null)
        {
            GameObject go = Instantiate(spawn.ObjectToSpawn, GetRandomPosition(spawn.StartX, spawn.EndX, spawn.StartY, spawn.EndY), Quaternion.identity);
            Debug.Log(spawn.ObjectToSpawn.name);
            go.GetComponent<Enemy>().Name = spawn.ObjectToSpawn.name;
            EnemyManager.EnemyManagerRef.AddAliveEnemies(go);
        }
        else
        {
            enemy.transform.position = GetRandomPosition(spawn.StartX, spawn.EndX, spawn.StartY, spawn.EndY);
            enemy.GetComponent<NoDamageTimer>().enabled = true;
            enemy.GetComponent<Enemy>().enabled = false;
            enemy.SetActive(true);
        }

    }
}
