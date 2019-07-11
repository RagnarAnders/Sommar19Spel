using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    [SerializeField]
    private Vector3 offset;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.PlayerReference.transform;
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
