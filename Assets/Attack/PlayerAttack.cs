using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f; // Portée de l'attaque
    public float attackDamage = 10f; // Dégâts infligés par l'attaque
    public LayerMask enemyLayer; // Couche des ennemis
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;


    public GameObject anim1;
    public GameObject anim2;
    public GameObject anim3;
    public GameObject anim4;
    public GameObject anim5;

    
    
    private void Start()
    {
       
    }

    private void Update()
    {
   
        if (Input.GetKeyDown(KeyCode.A)) //attaque 1
        {
            anim1.SetActive(true);
            PressButtonColorChange(button1);
            Attack1();
            
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim1.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Z)) // attque 2 
        {

            anim2.SetActive(true);
            PressButtonColorChange(button2);
            Attack2();

        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            anim2.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E)) // attque 3 
        {

            anim3.SetActive(true);
            PressButtonColorChange(button3);
            Attack3();

        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            anim3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R)) // attaque 4 
        {

            anim4.SetActive(true);
            PressButtonColorChange(button4);
            Attack4();

        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            anim4.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.S)) // attaque 5 
        {

            anim5.SetActive(true);
            PressButtonColorChange(button5);
            Attack5();

        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim5.SetActive(false);
        }

    }

    //attaque 1

    public void Attack1()
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

    //attaque 2
    public void Attack2()
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

    //attaque 3

    public void Attack3()
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

    //attaque 4

    public void Attack4()
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

    //attaque 5

    public void Attack5()
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


    IEnumerator ButtonColorCoroutine(Button button) // Coroutine pour chagement couleur bouton
    {
        // suspend execution for 2 seconds
        yield return new WaitForSeconds(0.1f);
        SetNormalColor(button);
       
    }

    public void PressButtonColorChange(Button button)
    {
        SetPressedColor(button);
        StartCoroutine(ButtonColorCoroutine(button));

    }

    void SetPressedColor(Button button)
    {
        button.image.color = button.colors.pressedColor;
    }

    void SetNormalColor(Button button)
    {
        button.image.color = button.colors.normalColor;
    }

    private void OnDrawGizmosSelected()
    {
        // Dessine une sphère pour représenter la portée d'attaque dans l'éditeur
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}