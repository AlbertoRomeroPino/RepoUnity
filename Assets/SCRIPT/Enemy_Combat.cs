using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 1;


    private void OnCollisionEnter2D(Collision2D collsion)
    {
        collsion.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
    }
}
