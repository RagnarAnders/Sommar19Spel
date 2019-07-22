using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float fireSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject spawnPosition;
    public static Player PlayerReference { get; private set; }
    public int lives;
    private float fireRateTimer;

    private void Awake()
    {
        if(PlayerReference == null)
        {
            PlayerReference = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && fireRateTimer <= 0)
        {
            fireRateTimer = fireRate;
            ShootEvent se = new ShootEvent(spawnPosition.transform.position, transform, fireSpeed, bullet, 0.5f);
            se.FireEvent();
        }
        fireRateTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);

        transform.position += (Vector3)movement * speed * Time.deltaTime;

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
