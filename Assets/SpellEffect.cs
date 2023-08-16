using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpellEffect : MonoBehaviour
{


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
    public void BlinkEffect(SpellScriptableObject spell, Vector3 endPoint)
    {
        PlayerDeplacement playerDeplacement = GameManager.instance.prefabPlayer.GetComponent<PlayerDeplacement>();
        playerDeplacement.Blink(spell.spellTime, endPoint);

        //Blink marche sur le player uniquement ici => Il faut le faire fonctionner sur le spell également

    }

    //---------Définition des combinaisons d'effets--------------

    public void SetSpellActiveEffect(SpellScriptableObject spell, Collider enemy)
    {
        if (spell.spellEffect == "Dommage")
        {
            // Inflige des dégâts à l'ennemi
            DammageEffect(spell, enemy);

        }
        else if (spell.spellEffect == "Slow")
        {
            // Ralenti la cible
            SlowEffect(spell, enemy);
        }
    }





}
