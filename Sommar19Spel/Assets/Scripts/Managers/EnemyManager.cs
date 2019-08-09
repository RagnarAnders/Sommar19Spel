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
        if(EnemyIsEmpty())
        {
            return null;
        }
        else
        {
            return enemies.Dequeue();
        }
    }

}
