using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager EnemyManagerRef { get; private set; }
    private Dictionary<string, Queue<GameObject>> deadEnemies;
    private Dictionary<string, Queue<GameObject>> aliveEnemies;
    private Queue<GameObject> enemies;
    // Start is called before the first frame update
    void Awake()
    {
        if(EnemyManagerRef == null)
        {
            EnemyManagerRef = this;
        }
        if(enemies == null)
        {
            enemies = new Queue<GameObject>();
        }
        if(deadEnemies == null)
        {
            deadEnemies = new Dictionary<string, Queue<GameObject>>();
        }
    }

    public GameObject GetObject(GameObject enemy)
    {
        Queue<GameObject> tempEnemies;
        if (deadEnemies.ContainsKey(enemy.name))
        {
            tempEnemies = deadEnemies[enemy.name];
            return tempEnemies.Dequeue();
            //return 
        }
        else
        {
            return null;
        }
    }

    public void AddAliveEnemiesToDictionary(GameObject enemy)
    {
        if (!enemy.GetComponent<Enemy>())
        {
            return;
        }
        string name = enemy.name;
        Queue<GameObject> tempEnemies;
        if (aliveEnemies.ContainsKey(name))
        {
            tempEnemies = deadEnemies[name];
        }
        else
        {
            tempEnemies = new Queue<GameObject>();
        }
        tempEnemies.Enqueue(enemy);
        aliveEnemies.Add(name, tempEnemies);
    }

    public void AddDeadEnemiesToDictionary(GameObject enemy)
    {
        if (!enemy.GetComponent<Enemy>())
        {
            return;
        }
        string name = enemy.name;
        Queue<GameObject> tempEnemies;
        if (deadEnemies.ContainsKey(name))
        {
            tempEnemies = deadEnemies[name];
        }
        else
        {
            tempEnemies = new Queue<GameObject>();
        }
        tempEnemies.Enqueue(enemy);
        deadEnemies.Add(name, tempEnemies);
    }

    public void RemoveDeadEnemy(GameObject enemy)
    {

    }
    
    public void AddToList(GameObject enemy)
    {
        if (!enemy.GetComponent<Enemy>())
        {
            return;
        }
        else
        {
            enemies.Enqueue(enemy);
        }
    }

    public bool EnemyIsEmpty()
    {
        return enemies.Count == 0;
    }

    public GameObject GetEnemy()
    {
        return EnemyIsEmpty() ? null : enemies.Dequeue();
    }

}
