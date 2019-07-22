using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Player.PlayerReference.transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * moveSpeed;
    }

    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.Equals(Player.PlayerReference.GetComponent<Collider2D>()))
        {
            return;
        }
        Destroy(gameObject);
    }

}
