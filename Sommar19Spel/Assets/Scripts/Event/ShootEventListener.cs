using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEventListener : EventListener<ShootEvent>
{
    protected override void OnEvent(ShootEvent shootEvent)
    {
        GameObject go = Instantiate(shootEvent.Bullet, shootEvent.SpawnPosition, Quaternion.identity);
        Destroy(go, 0.5f);
    }
}
