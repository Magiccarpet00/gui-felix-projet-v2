using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Points de vie maximum de l'ennemi
    private int currentHealth; // Points de vie actuels de l'ennemi

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // R�duit les points de vie actuels de l'ennemi

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
