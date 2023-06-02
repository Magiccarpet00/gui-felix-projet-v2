using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f; // Portée de l'attaque
    public int attackDamage = 10; // Dégâts infligés par l'attaque
    public LayerMask enemyLayer; // Couche des ennemis
    public GameObject fire;


    //private Animator animator; // Référence à l'animator du personnage

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // Vérifie si le bouton d'attaque est enfoncé
        {

            fire.SetActive(true); 
            Attack();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            fire.SetActive(false);
        }

    }

    private void Attack()
    {
        //animator.SetTrigger("Attack"); // Déclenche l'animation d'attaque dans l'animator

        // Détection des ennemis dans la zone d'attaque
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            // Inflige des dégâts à l'ennemi
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dessine une sphère pour représenter la portée d'attaque dans l'éditeur
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}