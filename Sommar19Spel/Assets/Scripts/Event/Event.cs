﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event<T> where T : Event<T>
{
    private bool hasFired;

    public delegate void EventListener(T info);
    public static event EventListener Listeners;

    public static void RegisterListener(EventListener listener)
    {
        Listeners += listener;
    }

    public static void UnregisterListener(EventListener listener)
    {
        Listeners -= listener;
    }

    public void FireEvent()
    {
        if (hasFired)
        {
            throw new Exception("This event has already fired, to prevent infinite loops, you can't refire an event.");
        }
        hasFired = true;

        Listeners?.Invoke(this as T);
    }
}

public class SoundEvent : Event<SoundEvent>
{
    public Transform entity;
    public AudioClip audioClip;

    public SoundEvent(Transform entity, AudioClip audioClip)
    {
        this.audioClip = audioClip;
        this.entity = entity;
    }
}

public class ParticleEvent : Event<ParticleEvent>
{
    public Transform entity;
    public ParticleSystem particle;

    public ParticleEvent(Transform entity, ParticleSystem particle)
    {
        this.entity = entity;
        this.particle = particle;
    }
}

public class ShootEvent : Event<ShootEvent>
{
    public Vector2 SpawnPosition { get; private set; }
    public Transform Transform { get; private set; }
    public float Speed { get; private set; }
    public GameObject Bullet { get; private set; }
    
    /// <summary>
    /// Thees are the attribtes of the weapon.
    /// </summary>
    /// <param name="spawnPosition"> Where the bullet should spawn</param>
    /// <param name="direction"> What direction the bullet goes</param>
    /// <param name="speed"> How fast it should go</param>
    /// <param name="bullet"> The bullet itself</param>
    /// <param name="fireRate"> How fast or slow firerate</param>
    public ShootEvent(Vector2 spawnPosition, Transform transform , GameObject bullet)
    {
        SpawnPosition = spawnPosition;
        Transform = transform;
        Bullet = bullet;
    }
}

public class SpawnEvent : Event<SpawnEvent>
{
    public GameObject ObjectToSpawn { get; private set; }
    public float StartX { get; private set; }
    public float EndX { get; private set; }
    public float StartY { get; private set; }
    public float EndY { get; private set; }

    /// <summary>
    /// This function spawns the object in a random position inside theese four values.
    /// </summary>
    /// <param name="objectToSpawn"></param>
    /// <param name="startX"> startposition of the gamemap</param>
    /// <param name="endX"> endposition of the gamemap</param>
    /// <param name="startY"> startposition of the gamemap</param>
    /// <param name="endY"> endposition of the gamemap</param>
    public SpawnEvent(GameObject objectToSpawn, float startX, float endX, float startY, float endY)
    {
        ObjectToSpawn = objectToSpawn;
        StartX = startX;
        EndX = endX;
        StartY = startY;
        EndY = endY;
    }
}

public class SpawnEnemyEvent : SpawnEvent
{
    public SpawnEnemyEvent(GameObject objectToSpawn, float startX, float endX, float startY, float endY) 
        : base(objectToSpawn, startX, endX, startY, endY)
    {

    }
}

public class DeathEvent : Event<DeathEvent>
{
    public GameObject entity;
    public AudioClip deathSound;
    public ParticleSystem deathParticle;

    public DeathEvent(GameObject entity, AudioClip deathSound, ParticleSystem deathParticle)
    {
        this.entity = entity;
        this.deathSound = deathSound;
        this.deathParticle = deathParticle;
    }
}

public class TakeDamageEvent : Event<TakeDamageEvent>
{
    public GameObject entity;
    public AudioClip sound;
    public ParticleSystem particle;

    public TakeDamageEvent(GameObject entity, AudioClip sound, ParticleSystem particle)
    {
        this.entity = entity;
        this.sound = sound;
        this.particle = particle;
    }
}