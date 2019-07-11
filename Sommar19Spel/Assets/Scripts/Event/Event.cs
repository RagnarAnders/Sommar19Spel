using System;
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

}

public class ParticleEvent : Event<ParticleEvent>
{

}

public class ShootEvent : Event<ShootEvent>
{
    public Vector2 SpawnPosition { get; private set; }
    public Vector2 Direction { get; private set; }
    public float Speed { get; private set; }
    public GameObject Bullet { get; private set; }
    public float Firerate { get; private set; }
    
    /// <summary>
    /// Thees are the attribtes of the weapon.
    /// </summary>
    /// <param name="spawnPosition"> Where the bullet should spawn</param>
    /// <param name="direction"> What direction the bullet goes</param>
    /// <param name="speed"> How fast it should go</param>
    /// <param name="bullet"> The bullet itself</param>
    /// <param name="fireRate"> How fast or slow firerate</param>
    public ShootEvent(Vector2 spawnPosition, Vector2 direction, float speed, GameObject bullet, float firerate)
    {
        SpawnPosition = spawnPosition;
        Direction = direction;
        Speed = speed;
        Bullet = bullet;
        Firerate = firerate;
    }
}

public class DeathEvent : Event<DeathEvent>
{

}