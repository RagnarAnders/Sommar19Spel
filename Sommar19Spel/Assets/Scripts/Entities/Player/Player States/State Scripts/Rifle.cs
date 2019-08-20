using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Rifle")]
public class Rifle : PlayerBaseState
{
    [SerializeField] private AudioClip shotSound;
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
            SoundEvent sound = new SoundEvent(owner.transform, shotSound);
            sound.FireEvent();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            //owner.Transition<GrenadeLauncher>();
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
