using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    private int lastX, lastY;
    private Dictionary<int, Dictionary<int, Node>> matrix = 
        new Dictionary<int, Dictionary<int, Node>>();
    public Node[][] matrixNodes;

    Grid grid;
    private void Start()
    {
        int children = transform.childCount;
        matrixNodes = new Node[children][];
        for (int x = 0; x < children; x++)
        {
            matrixNodes[x] = new Node[transform.GetChild(x).childCount];
            for (int y = 0; y < transform.GetChild(x).childCount; y++)
            {
                NodeValue nodeValue;
                if (transform.GetChild(x).GetChild(y).GetComponent<Collider2D>())
                {
                    nodeValue = NodeValue.BLOCKED;
                }
                else
                {
                    nodeValue = NodeValue.CLEAR;
                }
                matrixNodes[x][y] = new Node(transform.GetChild(x).GetChild(y).gameObject,
                    nodeValue);
                lastY = y;
            }
            lastX = x;
        }
        Connect();
        GoThru();
    }

    private void Connect()
    {
        for (int x = 0; x < transform.childCount; x++)
        {
            for (int y = 0; y < transform.GetChild(x).childCount; y++)
            {
                for (int xvalue = -1; x < 1; x++)
                {
                    for (int yvalue = -1; x < 1; x++)
                    {
                        if (x + xvalue > 0 && y + yvalue > 0 && x + xvalue < lastX && y + yvalue < lastY)
                        {
                            Debug.Log("x valeu : " + (x + xvalue));
                            Debug.Log("y valeu : " + (y + yvalue));
                            if (matrixNodes[x][y] != matrixNodes[xvalue][yvalue])
                            {
                                matrixNodes[x][y].AddConnection(matrixNodes[xvalue][yvalue]);
                            }
                        }
                    }
                }
            }
        }
    }

    public void GoThru()
    {
        for (int x = 0; x < transform.childCount; x++)
        {
            for (int y = 0; y < transform.GetChild(x).childCount; y++)
            {
                matrixNodes[x][y].GetGameObject().GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}

