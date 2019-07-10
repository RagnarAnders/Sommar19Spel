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
        float maxDistanceDelta = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, Player.PlayerReference.transform.position, maxDistanceDelta);
        //transform.LookAt(Player.PlayerReference.transform.position);
    }

}
