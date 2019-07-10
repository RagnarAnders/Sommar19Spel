using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }
}
