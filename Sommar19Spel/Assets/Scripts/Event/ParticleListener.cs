using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleListener : EventListener<ParticleEvent>
{
    protected override void OnEvent(ParticleEvent eventType)
    {
        Instantiate(eventType.entity, eventType.entity.position, Quaternion.identity);
    }
}
