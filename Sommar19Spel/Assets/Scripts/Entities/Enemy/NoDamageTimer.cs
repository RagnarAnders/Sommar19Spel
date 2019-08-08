using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDamageTimer : MonoBehaviour
{
    [SerializeField] private float timer, countDown;
    private float changeCollorTimer;
    private bool color;
    private Color red;
    private void Start()
    {
        red = GetComponent<SpriteRenderer>().color;
        color = false;
        changeCollorTimer = timer / 5;
    }
    private void Update()
    {
        countDown -= Time.deltaTime;
        changeCollorTimer -= Time.deltaTime;
        if (countDown <= 0)
        {
            gameObject.GetComponent<Enemy>().enabled = true;
            GetComponent<SpriteRenderer>().color = red;
            countDown = timer;
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
