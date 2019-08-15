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
    int counter = 0;

    void Start()
    {

        direction = Player.PlayerReference.transform.up;
    }

    void Update()
    {
  
        transform.position += transform.up * speed * Time.deltaTime;

        Ray2D ray = new Ray2D(transform.position, transform.up);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Time.deltaTime * speed + detection, collisionMask);
        if (hit.collider != null)
        { 
            Vector2 v = Vector2.Reflect(ray.direction, hit.normal);
            float rot = Mathf.Atan2(v.x, v.y) * Mathf.Rad2Deg;
            transform.up = v;
            counter++;
            speed += 0.5f;
        }
    }

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Collision");
        if (collider.CompareTag("Enemy"))
        {
            collider.gameObject.GetComponent<HealthComponent>().TakeDamage(50);
            ShakeCamera.ShakeCameraRef.Shake(0.01f, 0.2f);

            Destroy(gameObject);
        }
        else if (collider.Equals(Player.PlayerReference.GetComponent<Collider2D>()))
        {
            if(counter > 0)
            {
                Player.PlayerReference.Damaged();
                Destroy(gameObject);
            }
         

        }


    }
}
