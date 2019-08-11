using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleListener : EventListener<ParticleEvent>
{
    protected override void OnEvent(ParticleEvent eventType)
    {
        ParticleSystem p = Instantiate(eventType.particle, eventType.entity.position, Quaternion.identity);
        //p.GetComponent<GameObject>();
        
        Destroy(p.gameObject, eventType.particle.main.duration);
    }
}
