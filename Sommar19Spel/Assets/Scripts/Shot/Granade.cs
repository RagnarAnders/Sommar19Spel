using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : Shot
{
    [SerializeField] private GameObject explosion;
    private void OnDestroy()
    {
        GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
