using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundListener : EventListener<SoundEvent>
{
    //[SerializeField] private int amoutOfSounds;
    //private static int number;
    protected override void OnEvent(SoundEvent eventType)
    {
        //varje gång ett ljud spelas så ska den plussa på i "number" och varje gång den slutas så ska den gå minus.
        //så man kan hålla ett maximalt antal ljud
        //if(number < amoutOfSounds)
        //{
            AudioSource.PlayClipAtPoint(eventType.audioClip, eventType.entity.position, 1.0f);
        
        //    number++;
        //}
        //else
        //{

        //}
    }
}
