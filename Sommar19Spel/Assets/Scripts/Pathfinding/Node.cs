using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeValue
{
    CLEAR = 0,
    BLOCKED = 1
}

public class Node
{
    private GameObject go;
    private NodeValue walkable;
    private List<Node> connections;

    public Node(GameObject go, NodeValue walkable)
    {
        this.go = go;
        this.walkable = walkable;
    }

    public void AddConnection(Node connection)
    {
        if (connections == null)
        {
            connections = new List<Node>();
        }
        connections.Add(connection);
    }

    public GameObject GetGameObject() {
        return go;
    }
}