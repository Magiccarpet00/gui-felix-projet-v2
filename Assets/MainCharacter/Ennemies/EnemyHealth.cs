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
        currentHealth -= damage; // Réduit les points de vie actuels de l'ennemi

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Code à exécuter lorsque l'ennemi est vaincu
        // Par exemple, jouer une animation de mort, détruire l'ennemi, etc.
        Destroy(gameObject);
    }
}
