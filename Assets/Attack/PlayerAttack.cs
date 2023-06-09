using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f; // Port�e de l'attaque
    public float attackDamage = 10f; // D�g�ts inflig�s par l'attaque
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

    private SpellsFusionUI displaySpell;

    public int spellIDButton;
    [SerializeField] SpellsUI spellUI;
    [SerializeField] SpellsFusionUI spellFusionUI;
    [SerializeField] BuildManagerScript buildManagerScript;


    private void Start()
    {
        displaySpell = GameObject.Find("SpellsFusionBG").GetComponent<SpellsFusionUI>();
       

    }

    private void Update()
    {
        if (spellFusionUI.childCount < 4)
            {

            if (Input.GetKeyDown(KeyCode.A)) //attaque 1
            {
                GameObject targetImage1;
                targetImage1 = GameObject.Find("TargetImage1");

                anim1.SetActive(true);
                PressButtonColorChange(button1);


                Attack1(targetImage1);

            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                anim1.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Z)) // attaque 2 
            {
                GameObject targetImage2;
                targetImage2 = GameObject.Find("TargetImage2");

                anim2.SetActive(true);
                PressButtonColorChange(button2);
                Attack2(targetImage2);

            }

            if (Input.GetKeyUp(KeyCode.Z))
            {
                anim2.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E)) // attaque 3 
            {
                GameObject targetImage3;
                targetImage3 = GameObject.Find("TargetImage3");

                anim3.SetActive(true);
                PressButtonColorChange(button3);
                Attack3(targetImage3);

            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                anim3.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.R)) // attaque 4 
            {
                GameObject targetImage4;
                targetImage4 = GameObject.Find("TargetImage4");

                anim4.SetActive(true);
                PressButtonColorChange(button4);
                Attack4(targetImage4);

            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                anim4.SetActive(false);
            }

        }
    }

    //attaque 1

    public void Attack1(GameObject g)
    {
        displaySpell.DisplaySpell(g); //DisplaySpell d�clar�e dans SpellsFusionUI.cs

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

        spellIDButton = spellUI.spellBuildActif[0].spellID; // r�cup�re l'ID du scriptableobject spell lanc� 
        buildManagerScript.spellCombinaisonList.Add(spellIDButton); // l'ajoute � la combinaison de quatre �l�ments (liste dans le BuildManager)


    }

    //attaque 2
    public void Attack2(GameObject g)
    {
        displaySpell.DisplaySpell(g);
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

        spellIDButton = spellUI.spellBuildActif[1].spellID; // r�cup�re l'ID du scriptableobject spell lanc� 
        buildManagerScript.spellCombinaisonList.Add(spellIDButton); // l'ajoute � la combinaison de quatre �l�ments (liste dans le BuildManager)


    }

    //attaque 3

    public void Attack3(GameObject g)
    {
        displaySpell.DisplaySpell(g);
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

        spellIDButton = spellUI.spellBuildActif[2].spellID; // r�cup�re l'ID du scriptableobject spell lanc� 
        buildManagerScript.spellCombinaisonList.Add(spellIDButton); // l'ajoute � la combinaison de quatre �l�ments (liste dans le BuildManager)
    }

    //attaque 4

    public void Attack4(GameObject g)
    {
        displaySpell.DisplaySpell(g);
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

        spellIDButton = spellUI.spellBuildActif[3].spellID; // r�cup�re l'ID du scriptableobject spell lanc� 
        buildManagerScript.spellCombinaisonList.Add(spellIDButton); // l'ajoute � la combinaison de quatre �l�ments (liste dans le BuildManager)
    }

    //attaque 5

    public void Attack5(GameObject g)
    {
        displaySpell.DisplaySpell(g);
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


    IEnumerator ButtonColorCoroutine(Button button) // Coroutine pour changement couleur bouton

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
        // Dessine une sph�re pour repr�senter la port�e d'attaque dans l'�diteur
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}