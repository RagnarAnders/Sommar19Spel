using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundListener : EventListener<SoundEvent>
{
    protected override void OnEvent(SoundEvent eventType)
    {
        AudioSource.PlayClipAtPoint(eventType.audioClip, eventType.entity.position, 1.0f);
    }
}
