using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShot : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    Vector2 Velocity;
    bool hit = false;
    Vector2 direction;

    void Start()
    {

        direction = Player.PlayerReference.transform.up;
    }

    private void Update()
    {
        Velocity = direction * Time.deltaTime * moveSpeed;
        transform.position += (Vector3)Velocity;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision");
        if (collision.otherCollider.CompareTag("Enemy") || collision.Equals(Player.PlayerReference.GetComponent<Collider2D>()))
        {
            collision.gameObject.GetComponent<HealthComponent>().TakeDamage(50);
            ShakeCamera.ShakeCameraRef.Shake(0.01f, 0.2f);

            Destroy(gameObject);
        }
        else
        {

            Debug.Log("Velocity Before: " + Velocity);


            direction = Vector2.Reflect(Velocity, collision.contacts[0].normal);
            Velocity = Vector2.zero;
            Debug.Log("Velocity After: " + Velocity);


        }


    }
}
