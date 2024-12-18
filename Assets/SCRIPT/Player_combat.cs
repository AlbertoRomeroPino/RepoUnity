using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player_combat : MonoBehaviour
{

    public Transform attackPoint;
    public float weaponRange = 1;
    public float knockbackForce = 50;
    public float knockbackTime = .15f;
    public float stunTime = .3f;
    public LayerMask enemyLayer;
    public int damage = 1;

    public Animator anim;

    public float cooldown = 2;
    private float timer;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

    }

    public void Attack()
    {
        anim.SetBool("isAttacking", true);

        

        timer = cooldown;
    }

    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);

        if(enemies.Length > 0)
        {
            for (int i = 0; i < enemies.Length; i++) {
            enemies[i].GetComponent<Enemy_Health>().ChangeHealth(-damage);
            enemies[i].GetComponent<Enemy_Knockback>().Knockback(transform, knockbackForce,knockbackTime, stunTime);
            }
        }
    }

    public void FinishAttacking()
    {
        if (timer <= 0)
        {
            anim.SetBool("isAttacking", false);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }

}
