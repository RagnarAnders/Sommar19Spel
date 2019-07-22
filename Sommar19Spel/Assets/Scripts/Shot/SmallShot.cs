using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShot : Shot
{
    override protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.Equals(Player.PlayerReference.GetComponent<Collider2D>()))
        {
            return;
        }
        Destroy(gameObject);
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
