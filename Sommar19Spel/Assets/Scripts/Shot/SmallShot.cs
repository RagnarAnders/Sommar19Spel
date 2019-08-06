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
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthComponent>().TakeDamage(50);
            ShakeCamera.ShakeCameraRef.enabled = true;
            //lägg till en screenshake här
        }
        Destroy(gameObject);
    }
}
