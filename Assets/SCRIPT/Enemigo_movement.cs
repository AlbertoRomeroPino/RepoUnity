using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemigo_movement : MonoBehaviour
{
    public float speed = 4f;
    private bool isChasing;
    private bool miraDerecha = true;
    private EnemyState enemyState;

    public float attackRange = 2;

    private Rigidbody2D rb;
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing == true)
        {
            Chase();
        }
        else if(enemyState == EnemyState.Attacking)
        {

        }
        else
        {
            rb.velocity = rb.velocity * 0f;
        }

    }

    void Chase()
    {
        if (player.position.x > transform.position.x && !miraDerecha ||
            player.position.x < transform.position.x && miraDerecha)
            {
                Flip();

            }
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;
    }

    void Flip()
    {
        miraDerecha = !miraDerecha;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            if (player == null)
            {
                player = collision.transform;
            }
        isChasing = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isChasing = false;
        }
    }
}

public enum EnemyState
{
    Idle,
    isChasing,
    Attacking
}
