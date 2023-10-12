using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;
    

    public GameObject anim1;
    public GameObject anim2;
    public GameObject anim3;
    public GameObject anim4;
    public GameObject anim5;

    public EnnemySpellPlacement instantiateEnnemySpellPlacement;
    public SpellZone instantiateSpellZone;


    public SpellScriptableObject spellToCast;

    public bool isCasting;

    DeplacementEnnemy deplacementEnnemy;
    public float timeBetweenCasts;




    private void Start()
    {
        deplacementEnnemy = GetComponent<DeplacementEnnemy>();
    }

    private void Update()
    {
    
        if(deplacementEnnemy.hasDetectedPlayer == true && isCasting == false)
        {
            StartCoroutine(EnnemyCastSpellCoroutine(timeBetweenCasts, spellToCast));
        }

    }
       

    public void CastSpell(SpellScriptableObject spell)
    {
       
        GameManager.instance.InstantiateNewSpell(transform);

        SpellLifeTime lifeTime = GameManager.instance.newSpell.AddComponent<SpellLifeTime>();
        lifeTime.SpellDie(spell.spellLifeTime);

        instantiateSpellZone = GameManager.instance.newSpell.AddComponent<SpellZone>();
        instantiateSpellZone.ownerSpellZone = transform;

        if (spell.spellLifeTime != 0)
        {
            instantiateEnnemySpellPlacement = GameManager.instance.newSpell.AddComponent<EnnemySpellPlacement>();
            instantiateEnnemySpellPlacement.ownerEnnemy = transform;
        }

        if (spell.spellZone == "Sphere")
        {
            instantiateSpellZone.Sphere(spell);

        }
        else if (spell.spellZone == "Cone")
        {

            instantiateSpellZone.Cone(spell);
        }
        else if (spell.spellZone == "Ray")
        {
            instantiateSpellZone.Ray(spell);
        }
        else if (spell.spellZone == "Allonge")
        {
            instantiateSpellZone.Allonge(spell);
        }
        else if (spell.spellZone == "")
        {
            instantiateSpellZone.NoZone(spell);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.PlayerTakeDamage(10);
        }
    }

    IEnumerator EnnemyCastSpellCoroutine (float castSpellTime, SpellScriptableObject spell)
    {
        isCasting = true;
        CastSpell(spell);
        yield return new WaitForSeconds(castSpellTime + spell.spellLifeTime);
        isCasting = false;
    }
}
