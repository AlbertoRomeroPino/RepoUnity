using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_combat : MonoBehaviour
{
    public Animator anim;
    private float timer;

    private void Update()
    {
        if(timer > 0 )
        {
            timer -= Time.deltaTime;
        }

    }

    public void Attack()
    {
        anim.SetBool("isAttacking", true);
    }

    public void FinishAttacking()
    {
         anim.SetBool("isAttacking", false);

    }
    
    
    }
