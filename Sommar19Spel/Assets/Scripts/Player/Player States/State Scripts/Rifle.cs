using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Rifle")]
public class Rifle : PlayerBaseState
{
    public override void Enter()
    {
        base.Enter();
    }
    public override void HandleUpdate()
    {
        if (Input.GetMouseButton(0) && fireRateTimer <= 0)
        {
            //ShootRifle();
            Shoot(bullet, fireSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            owner.Transition<GrenadeLauncher>();
        }
        base.HandleUpdate();
    }

    private void ShootRifle()
    {
        RaycastHit2D hit = Physics2D.Raycast(owner.SpawnPosition.transform.position, owner.transform.up);
        if (hit.collider.CompareTag("Enemy"))
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
