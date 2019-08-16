using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEventListener : EventListener<SpawnEvent>
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] float distanceFromPlayer;
    protected GameObject spawnObject;
    protected override void OnEvent(SpawnEvent spawn)
    {
        spawnObject = spawn.ObjectToSpawn;
        GameObject go = Instantiate(spawn.ObjectToSpawn, GetRandomPosition(spawn.StartX, spawn.EndX, spawn.StartY, spawn.EndY), Quaternion.identity);
    }

    protected Vector2 GetRandomPosition(float startX, float endX, float startY, float endY)
    {
        Vector2 spawnLocation = Vector2.zero;
        bool colliding;
        bool toCloseToPlayer;
        do
        {
            float randomX = Random.Range(startX, endX);
            float randomY = Random.Range(startY, endY);

            spawnLocation = new Vector2(randomX, randomY);

            colliding = CheckOverlap(spawnLocation);
            toCloseToPlayer = ChechDistance(spawnLocation);

        } while (colliding || toCloseToPlayer);
        
        return spawnLocation;
    }

    protected bool CheckOverlap(Vector2 spawnLocation)
    {
        return Physics2D.OverlapBox(spawnLocation, spawnObject.transform.localScale, 0f, layerMask);
    }

    private bool ChechDistance(Vector2 spawnLocation)
    {
        return Vector2.Distance(Player.PlayerReference.transform.position, spawnLocation) < distanceFromPlayer ? true : false;
    }
}