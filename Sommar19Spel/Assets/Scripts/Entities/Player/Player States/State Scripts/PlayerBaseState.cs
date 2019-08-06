using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : State
{
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float fireSpeed;
    protected float fireRateTimer;

    protected Player owner;

    public override void Initialize(StateMachine owner)
    {
        this.owner = (Player)owner;
    }

    public override void Enter()
    {
        owner.Speed = speed;
    }

    public override void HandleUpdate()
    {
        fireRateTimer -= Time.deltaTime;
    }
    
    protected void Shoot(GameObject bullet, float fireSpeed)
    {
        fireRateTimer = fireRate;
        ShootEvent se = new ShootEvent(Player.PlayerReference.SpawnPosition.transform.position, Player.PlayerReference.transform, fireSpeed, bullet);
        se.FireEvent();
    }
}
