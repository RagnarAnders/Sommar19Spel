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
            Shoot(bullet, fireSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            owner.Transition<GrenadeLauncher>();
        }
        base.HandleUpdate();
    }
}
