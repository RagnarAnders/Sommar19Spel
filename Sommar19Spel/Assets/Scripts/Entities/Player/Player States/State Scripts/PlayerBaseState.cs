using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : State
{
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float fireSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTimer;

    protected float fireRateTimer;
    private float countDown;
    private bool isDashing;
    protected Player owner;

    public override void Initialize(StateMachine owner)
    {
        this.owner = (Player)owner;
    }

    public override void Enter()
    {
        owner.Speed = speed;
        countDown = dashTimer;
    }

    public override void HandleUpdate()
    {
        fireRateTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftControl) || isDashing == true)
        {
            Debug.Log("Dashing");
            owner.Speed = dashSpeed;
            isDashing = true;
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                countDown = dashTimer;
                owner.Speed = speed;
                isDashing = false;
            }
        }
    }

    protected void Shoot(GameObject bullet, float fireSpeed)
    {
        fireRateTimer = fireRate;
        ShootEvent se = new ShootEvent(Player.PlayerReference.SpawnPosition.transform.position, Player.PlayerReference.transform, fireSpeed, bullet);
        se.FireEvent();
    }
}
