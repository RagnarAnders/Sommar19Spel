using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField] private float speed;
    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Debug.Log("Move");
        Vector3.MoveTowards(transform.position, Player.PlayerReference.transform.position, speed);
    }
}
