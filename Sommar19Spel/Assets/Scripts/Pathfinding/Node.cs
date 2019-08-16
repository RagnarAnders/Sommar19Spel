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
    Vector2 position;
    NodeValue walkable;
    private List<Node> nodes;

    public Node(Vector2 position, NodeValue walkable)
    {
        this.position = position;
        this.walkable = walkable;
    }


}
