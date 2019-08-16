using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager EnemyManagerRef { get; private set; }
    private Dictionary<string, Queue<GameObject>> deadEnemies;
    private Dictionary<string, GameObject> aliveEnemies;
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
        if(aliveEnemies == null)
        {
            aliveEnemies = new Dictionary<string, GameObject>();
        }
    }

    public GameObject GetObject(GameObject enemy)
    {
        Queue<GameObject> dEnemies;

        string name = enemy.name;
        if (deadEnemies.ContainsKey(name))
        {
            dEnemies = deadEnemies[name];
            GameObject e = dEnemies.Dequeue();
            deadEnemies.Remove(name);
            deadEnemies.Add(name, dEnemies);
            aliveEnemies.Add(e.name, e);
            return e;
        }
        else
        {
            return null;
        }
    }

    public void AddAliveEnemies(GameObject enemy)
    {
        if (!enemy.GetComponent<Enemy>())
        {
            return;
        }
        aliveEnemies.Add(enemy.name, enemy);
    }

    public void AddDeadEnemiesToDictionary(GameObject enemy, string name)
    {
        if (!enemy.GetComponent<Enemy>())
        {
            Debug.Log("!ENEMY");
            return;
        }
        Queue<GameObject> tempEnemies;
        if (deadEnemies.ContainsKey(name))
        {
            tempEnemies = deadEnemies[name];
            deadEnemies.Remove(name);
        }
        else
        {
            tempEnemies = new Queue<GameObject>();
        }
        tempEnemies.Enqueue(enemy);
        deadEnemies.Add(name, tempEnemies);
        aliveEnemies.Remove(enemy.name);
    }




    public GameObject RemoveDeadEnemy(GameObject enemy)
    {
        Queue<GameObject> tempEnemies = deadEnemies[enemy.name];
        GameObject e = tempEnemies.Dequeue();
        aliveEnemies.Add(e.name, e);
        return e;
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
