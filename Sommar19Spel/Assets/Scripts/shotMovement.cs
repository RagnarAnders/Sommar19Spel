using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed;
    }
}
