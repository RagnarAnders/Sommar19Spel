using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    public string Name { get; set; }
    private Transform player;
    private void Start()
    {
        player = Player.PlayerReference.transform;
    }

    private void OnEnable()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    void Update()
    {
        if(player != null)
        {
            Rotate();
            Move();
        }
    }

    private void Move()
    {
        float maxDistanceDelta = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, maxDistanceDelta);

    }
    private void Rotate()
    {
        Quaternion rotation = Quaternion.LookRotation(
        player.transform.position - transform.position,
        transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.PlayerReference.Damaged();
        }
    }

    public void OnDisable()
    {
        GameController.Instance.UpdateScore(1);
        //EnemyManager.EnemyManagerRef.AddDeadEnemiesToDictionary(gameObject, Name);
    }
}
