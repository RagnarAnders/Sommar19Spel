using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShot : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector2 Velocity;
    Vector2 direction;

    public LayerMask collisionMask;
    public float detection = 0.01f;

    void Start()
    {

        direction = Player.PlayerReference.transform.up;
    }

    private void Update()
    {
        //Velocity = direction * Time.deltaTime * moveSpeed;
        //transform.position += (Vector3)Velocity;

        transform.position += transform.up * speed * Time.deltaTime;

        Ray2D ray = new Ray2D(transform.position, transform.up);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Time.deltaTime * speed + detection, collisionMask);
        if (hit.collider != null)
        {
            Debug.Log("Hit");
            //Debug.DrawLine(ray.origin, hit.point, Color.red);
            Vector2 v = Vector2.Reflect(ray.direction, hit.normal);
            Debug.Log("New vector: " + v);
            float rot = Mathf.Atan2(v.x, v.y) * Mathf.Rad2Deg;
            Debug.DrawRay(hit.point, v, Color.red);
            Debug.Log("Rotation: " + rot);
            transform.eulerAngles = new Vector3(0, 0, rot);
        }
    }

    //protected void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //Debug.Log("Collision");
    //    if (collision.otherCollider.CompareTag("Enemy") || collision.Equals(Player.PlayerReference.GetComponent<Collider2D>()))
    //    {
    //        collision.gameObject.GetComponent<HealthComponent>().TakeDamage(50);
    //        ShakeCamera.ShakeCameraRef.Shake(0.01f, 0.2f);

    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        Debug.Log("Velocity Before: " + Velocity);

    //        direction = Vector2.Reflect(Velocity, collision.contacts[0].normal);
    //        Velocity = Vector2.zero;
    //        Debug.Log("Velocity After: " + Velocity);

    //    }


    //}
}
