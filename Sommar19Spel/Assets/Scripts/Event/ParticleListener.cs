using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleListener : EventListener<ParticleEvent>
{
    protected override void OnEvent(ParticleEvent eventType)
    {
        Debug.Log("ParticleListener");
        Instantiate(eventType.particle, eventType.entity.position, Quaternion.identity);
    }
}
