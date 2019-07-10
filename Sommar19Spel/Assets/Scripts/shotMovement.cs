using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotMovement : MonoBehaviour
{
    public float moveSpeed;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Player.PlayerReference.transform.up;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * moveSpeed;
    }
}
