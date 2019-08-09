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
            GetComponent<SpriteRenderer>().color = red;
            countDown = timer;
            changeCollorTimer = timer / 5;
            enabled = false;
            gameObject.GetComponent<Enemy>().enabled = true;
        }
        else if (changeCollorTimer <= 0)
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
