using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEventListener : EventListener<SpawnEvent>
{
    [SerializeField] private LayerMask layerMask;
    private GameObject spawnObject;
    protected override void OnEvent(SpawnEvent spawn)
    {
        spawnObject = spawn.ObjectToSpawn;
        GameObject go = Instantiate(spawn.ObjectToSpawn, getRandomPosition(spawn.StartX, spawn.EndX, spawn.StartY, spawn.EndY), Quaternion.identity);
    }

    private Vector2 getRandomPosition(float startX, float endX, float startY, float endY)
    {
        Vector2 spawnLocation = Vector2.zero;
        bool colliding;
        do
        {
            float randomX = Random.Range(startX, endX);
            float randomY = Random.Range(startY, endY);

            spawnLocation = new Vector2(randomX, randomY);

            colliding = checkOverlap(spawnLocation);

        } while (colliding);

        return spawnLocation;
    }

    private bool checkOverlap(Vector2 spawnLocation)
    {
        return Physics2D.OverlapBox(spawnLocation, spawnObject.transform.localScale, 0f, layerMask);
    }
}