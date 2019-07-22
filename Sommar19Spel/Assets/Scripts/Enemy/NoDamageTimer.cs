using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDamageTimer : MonoBehaviour
{
    [SerializeField] private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameObject.GetComponent<Enemy>().enabled = true;
            enabled = false;
        }
    } 
}
