using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    [SerializeField] private GameObject spawnPosition;
   
    private Vector2 input;
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        input = new Vector2(horizontal, vertical);
        rbd.velocity = input.normalized * Speed;
    }

   
  
    public void Damaged()
    {
        lives--;
        if(lives == 0)
        { 
            GameController.Instance.GameOver();
            Died();
        }
    }
    

    public void Died()
    {
        enabled = false;
        //Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
