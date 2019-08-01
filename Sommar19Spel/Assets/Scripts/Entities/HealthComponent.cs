using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{

    public int Health { get; set; }

    [SerializeField] private int maxHealth;
    [SerializeField] private ParticleSystem takeDamageParticle;
    [SerializeField] private ParticleSystem deathParticle;
    [SerializeField] private AudioClip takeDamageSound;
    [SerializeField] private AudioClip deathSound;
   
    void Start()
    {
        Health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if(Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        DeathEvent deathEvent = new DeathEvent(this.gameObject, deathSound, deathParticle);
        deathEvent.FireEvent();
    }
}
