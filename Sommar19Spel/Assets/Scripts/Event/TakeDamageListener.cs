using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageListener : EventListener<TakeDamageEvent>
{
    protected override void OnEvent(TakeDamageEvent eventType)
    {
        SoundEvent soundEvent = new SoundEvent(eventType.entity.transform, eventType.sound);
        soundEvent.FireEvent();
        ParticleEvent particleEvent = new ParticleEvent(eventType.entity.transform, eventType.particle);
        particleEvent.FireEvent();
     
    }
}
