using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{

    public float maxHealth = 100f; // Points de vie maximum de l'ennemi
    private float currentHealth; // Points de vie actuels de l'ennemi
    public Image healthBar;

    private void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // R�duit les points de vie actuels de l'ennemi
        healthBar.fillAmount = currentHealth / maxHealth;


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Code � ex�cuter lorsque l'ennemi est vaincu
        // Par exemple, jouer une animation de mort, d�truire l'ennemi, etc.
        Destroy(gameObject);
    }
}
