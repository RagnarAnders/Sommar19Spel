using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject shot;
    public static Player PlayerReference { get; private set; }

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

        
        //float AngleRad = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x,
        //    Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y);

        //float AngleDeg = (180 / Mathf.PI) * AngleRad;

        //transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
