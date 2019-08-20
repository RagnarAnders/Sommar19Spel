using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject spawnPosition;
    [SerializeField] private float fireRate;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;

    protected float fireRateTimer;
    private Vector2 input;
    public static Player PlayerReference { get; private set; }
    public GameObject SpawnPosition { get => spawnPosition; private set => spawnPosition = value; }

    public int lives;
    private Rigidbody2D rbd;

    protected void Awake()
    {
        
        if(PlayerReference == null)
        {
            PlayerReference = this;
        }
        rbd = GetComponent<Rigidbody2D>();
        
    }
    
    private void FixedUpdate()
    {
        rbd.velocity = input.normalized * speed;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        input = new Vector2(horizontal, vertical);
        fireRateTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && fireRateTimer <= 0)
        {
            Fire(bullet);
        }
    }

    protected void Fire(GameObject bullet)
    {
        fireRateTimer = fireRate;
        ShootEvent se = new ShootEvent(Player.PlayerReference.SpawnPosition.transform.position, Player.PlayerReference.transform, bullet);
        se.FireEvent();
        SoundEvent sound = new SoundEvent(transform, fireSound);
        sound.FireEvent();
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
