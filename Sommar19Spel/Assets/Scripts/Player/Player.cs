using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    [SerializeField] private GameObject spawnPosition;
    public static Player PlayerReference { get; private set; }
    public GameObject SpawnPosition { get => spawnPosition; private set => spawnPosition = value; }
    public float Speed { get; set; }

    public int lives;
    private Rigidbody2D rbd;

    protected override void Awake()
    {
        
        if(PlayerReference == null)
        {
            PlayerReference = this;
        }
        rbd = GetComponent<Rigidbody2D>();
        base.Awake();
    }
    
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);

        //transform.position += (Vector3)movement * Speed * Time.deltaTime;
        //rbd.AddForce((Vector3)movement * Speed);

        //With velocity the player won't be able to bug itself thro walls it doesn't feel like it's moving on ice.
        rbd.velocity = movement * Speed;
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 rotateTo = (mouseScreenPosition - (Vector2)transform.position).normalized;

        transform.up = rotateTo;
    }

    public void Damaged()
    {
        lives--;
        if(lives == 0)
        { 
            GameController.instance.GameOver();
            Died();
        }
    }
    

    public void Died()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
