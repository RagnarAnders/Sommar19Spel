﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEventListener : EventListener<DeathEvent>
{
    protected override void OnEvent(DeathEvent eventType)
    {
        Debug.Log("DeathListener");
        SoundEvent soundEvent = new SoundEvent(eventType.entity.transform, eventType.deathSound);
        soundEvent.FireEvent();
        ParticleEvent particleEvent = new ParticleEvent(eventType.entity.transform, eventType.deathParticle);
        particleEvent.FireEvent();
        eventType.entity.SetActive(false);
        EnemyManager.EnemyManagerRef.AddToList(eventType.entity);
    }
}
