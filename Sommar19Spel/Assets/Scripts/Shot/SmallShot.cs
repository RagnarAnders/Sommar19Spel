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
            ShakeCamera.ShakeCameraRef.Shake(0.01f, 0.2f);
            //lägg till en screenshake här
        }
        Destroy(gameObject);
    }
}
