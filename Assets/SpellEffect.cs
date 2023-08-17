using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpellEffect : MonoBehaviour
{
    PlayerAttack playerAttack;


    public List<Collider> listTouchedEnemies = new List<Collider>();

    //---------------------Définition des effets-------------
    
    //---------------------Dommages-------------------
    public void DammageEffect(SpellScriptableObject spell, Collider enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null && !listTouchedEnemies.Contains(enemy))
        {
            enemyHealth.TakeDamage(spell.spellValue);
            listTouchedEnemies.Add(enemy);
        }

    }

    //---------------------Slow-------------------
    public void SlowEffect(SpellScriptableObject spell, Collider enemy)
    {
        DeplacementEnnemy enemyDeplacement = enemy.GetComponent<DeplacementEnnemy>();
        if (enemyDeplacement != null && !listTouchedEnemies.Contains(enemy))
        {
            enemyDeplacement.slowDeplacement(spell.spellValue, spell.spellTime);
            listTouchedEnemies.Add(enemy);
        }
    }

    //---------------------Blink-------------------
    public virtual void BlinkEffect(SpellScriptableObject spell, Vector3 endPoint)
    {
        if(GameManager.instance.isCastingMegaSpell == false)
        {
            PlayerDeplacement playerDeplacement = GameManager.instance.prefabPlayer.GetComponent<PlayerDeplacement>();
            playerDeplacement.BlinkPlayer(spell.spellTime, endPoint);

        }
        else if(GameManager.instance.isCastingMegaSpell == true)
        {
           
            BlinkSpell(spell.spellTime, endPoint);
        }
       

        //Blink marche sur le player uniquement ici => Il faut le faire fonctionner sur le spell également

    }

    

    //---------Définition des combinaisons d'effets--------------

    public void SetSpellColliderEffect(SpellScriptableObject spell, Collider enemy) //Blink n'est pas dans cette méthode 
    {
    
        if (spell.spellEffect[0] == "Dommage")
        {
            // Inflige des dégâts à l'ennemi
            DammageEffect(spell, enemy);
            

        }
        else if (spell.spellEffect[0] == "Slow")
        {
            // Ralenti la cible
            SlowEffect(spell, enemy);
        }

    }

    public void SetSpellNoColliderEffect(SpellScriptableObject spell, Vector3 interpolatePos)
    {

        if (spell.spellEffect[0] == "Blink")
        {
            BlinkEffect(spell, interpolatePos);
        }
    }

    // ----------- blink le spell-----------
    public void BlinkSpell(float blinkTime, Vector3 newPos)
    {
        StartCoroutine(BlinkSpellCoroutine(blinkTime, newPos));
    }

    public IEnumerator BlinkSpellCoroutine(float blinkTime, Vector3 newPos)
    {
        transform.position = newPos;
        yield return new WaitForSeconds(blinkTime);
    }









}
