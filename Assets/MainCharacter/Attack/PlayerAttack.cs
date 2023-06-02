using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f; // Port�e de l'attaque
    public int attackDamage = 10; // D�g�ts inflig�s par l'attaque
    public LayerMask enemyLayer; // Couche des ennemis
    public GameObject fire;


    //private Animator animator; // R�f�rence � l'animator du personnage

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // V�rifie si le bouton d'attaque est enfonc�
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
        //animator.SetTrigger("Attack"); // D�clenche l'animation d'attaque dans l'animator

        // D�tection des ennemis dans la zone d'attaque
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            // Inflige des d�g�ts � l'ennemi
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dessine une sph�re pour repr�senter la port�e d'attaque dans l'�diteur
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}