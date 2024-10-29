using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MOMIMIENTO : MonoBehaviour
{

public float speed = 5;
public int facingDirection = 1;

public Rigidbody2D rb;
public Animator anim; 
private bool isKnocKedBack;

public Player_combat player_Combat;

private void Update()
{
    if(Input.GetButtonDown("Slash"))
    {
        player_Combat.Attack();
    }
}

    // Fixed Update is called 50X frame
    void FixedUpdate(){
    if (isKnocKedBack == false)
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(horizontal > 0 && transform.localScale.x < 0 ||
           horizontal < 0 && transform.localScale.x > 0 )
    
           {
                Flip();
           }

        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));

    
        rb.velocity = new Vector2(horizontal, vertical) * speed;

    
    }
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
}