using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    public static AudioController AudioRef { get; private set;}
    public AudioSource Source { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (AudioRef == null)
        {
            AudioRef = this;
        }
        if(Source == null)
        {
            Source = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
