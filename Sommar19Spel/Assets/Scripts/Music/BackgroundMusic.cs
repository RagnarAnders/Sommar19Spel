using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;
    Random rnd;
    private void Awake()
    {
        if(rnd == null)
        {
            rnd = new Random();
        }
        audioSource = GetComponent<AudioSource>();
        PlayAudio();
    }

    private void PlayAudio()
    {
        int amount = audioClips.Length;
        float number = Random.Range(0, amount - 1);
        int num = (int)number;
        audioSource.PlayOneShot(audioClips[num]);
        Invoke("PlayAudio", audioClips[num].length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
