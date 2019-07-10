using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
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
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.IsTouchingLayers(LayerMask.GetMask("Wall")))
        {
            Destroy(gameObject);
        }
    }
}
