using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager EnemyManagerRef { get; private set; }

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
    }
    
    public void addToList(GameObject enemy)
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

    public bool enemyIsEmpty()
    {
        return enemies.Count == 0;
    }

    public GameObject getEnemy()
    {
        if(enemyIsEmpty())
        {
            return null;
        }
        else
        {
            return enemies.Dequeue();
        }
    }

}
