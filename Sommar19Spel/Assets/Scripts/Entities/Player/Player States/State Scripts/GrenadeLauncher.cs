using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Granade Launcher")]
public class GrenadeLauncher : PlayerBaseState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleUpdate()
    {
        if (Input.GetMouseButtonDown(0) && fireRateTimer <= 0)
        {
            Shoot(bullet, fireSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            //owner.Transition<Rifle>();
        }
        base.HandleUpdate();
    }
}