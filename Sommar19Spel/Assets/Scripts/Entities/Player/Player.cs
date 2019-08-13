using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    [SerializeField] private GameObject spawnPosition;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTimer;
    private float movementSpeed;
    private bool isDashing;
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
        rbd.velocity = input.normalized * movementSpeed;

    }
    protected void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        input = new Vector2(horizontal, vertical);
        if (Input.GetKeyDown(KeyCode.LeftControl) || isDashing == true)
        {
            Debug.Log("Dashing");
            movementSpeed = dashSpeed;
            isDashing = true;
            Invoke("Dash", dashTimer);
        }
        else
        {
            movementSpeed = Speed;
        }
    }

    private void Dash()
    {
        isDashing = false;
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
