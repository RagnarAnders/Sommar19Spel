using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] AudioClip audio;
    [SerializeField] private float timer;
    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
        if(Physics2D.OverlapCircle(gameObject.transform.position, 0.5f, LayerMask.GetMask("Player"))){
            ParticleEvent part = new ParticleEvent(gameObject.transform, particle);
            part.FireEvent();
            SoundEvent sound = new SoundEvent(gameObject.transform, audio);
            sound.FireEvent();
            Destroy(gameObject);
        }
        timer -= Time.deltaTime;
    }

    private void OnDestroy()
    {
        HighScore.HighscoreReference.UpdateScore(10);
    }
}
