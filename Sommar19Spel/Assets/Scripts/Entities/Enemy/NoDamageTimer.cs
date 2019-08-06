using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDamageTimer : MonoBehaviour
{
    [SerializeField] private float timer;
    private float changeCollorTimer;
    private bool color;
    private Color red;
    private Enemy enemy;
    private void Start()
    {
        red = GetComponent<SpriteRenderer>().color;
        color = false;
        changeCollorTimer = timer / 5;
        enemy = gameObject.GetComponent<Enemy>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        changeCollorTimer -= Time.deltaTime;
        if (timer <= 0)
        {
            enemy.enabled = true;
            enemy.Red = red;
            enabled = false;
        }
        if (changeCollorTimer <= 0)
        {
            if (color)
            {
                color = false;

                GetComponent<SpriteRenderer>().color = red;
            }
            else
            {
                color = true;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
            changeCollorTimer = timer / 5;
        }
    }
}
