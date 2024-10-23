using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo_movement : MonoBehaviour
{
    public float speed;
    private bool isChasing;

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
    if(isChasing == true){
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }      
    }

    private void OnTroggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player")
        {
        isChasing = true;
        }
    }

    private void OnTroggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player")
        {
        isChasing = false;
        }
}
}
