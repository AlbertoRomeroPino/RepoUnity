using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public TMP_Text healthText;
    public Animator healthaTextAnim;

    private void Start()
    {
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;   
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        healthaTextAnim.Play("TexUpdate");

        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
}
