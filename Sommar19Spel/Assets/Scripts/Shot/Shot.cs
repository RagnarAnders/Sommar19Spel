﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 direction;
    protected Vector2 Velocity;
    // Start is called before the first frame update
    void Start()
    {

        direction = Player.PlayerReference.transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update Velocity: " + Velocity);
        Velocity = direction * Time.deltaTime * moveSpeed;
        transform.position += (Vector3) Velocity;
    }

    
}
