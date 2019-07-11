using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    public static Player PlayerReference { get; private set; }
    public int lives;

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
