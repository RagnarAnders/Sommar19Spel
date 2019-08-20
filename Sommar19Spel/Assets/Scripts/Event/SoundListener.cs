using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundListener : EventListener<SoundEvent>
{
    [SerializeField] private int amountOfSounds;
    private static int amount;
    protected override void OnEvent(SoundEvent eventType)
    {
        if(amount < amountOfSounds)
        {
            amount++;
            AudioSource.PlayClipAtPoint(eventType.audioClip, eventType.entity.position, Random.Range(0.5f, 1.0f));
            Invoke("Decrease", eventType.audioClip.length);
        }
        else
        {
            return;
        }
        
    }

    private void Decrease()
    {
        amount--;
    }
}
