using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffect : MonoBehaviour
{
    private HashSet<Collider> touchedEnemies = new HashSet<Collider>();
    
    //---------------------Dommages-------------------
    public void DammageEffect(SpellScriptableObject spell, Collider enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(spell.spellValue);
        }

    }

    public void DammageBallEffect(SpellScriptableObject spell, Collider enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null && !touchedEnemies.Contains(enemy))
        {
            enemyHealth.TakeDamage(spell.spellValue);
            touchedEnemies.Add(enemy);
        }
    }

    //---------------------Slow-------------------
    public void SlowEffect(SpellScriptableObject spell, Collider enemy)
    {
        DeplacementEnnemy enemyDeplacement = enemy.GetComponent<DeplacementEnnemy>();
        if (enemyDeplacement != null)
        {
            enemyDeplacement.slowDeplacement(spell.spellValue,spell.spellTime);
        }

    }

    public void SlowBallEffect(SpellScriptableObject spell, Collider enemy)
    {
        DeplacementEnnemy enemyDeplacement = enemy.GetComponent<DeplacementEnnemy>();
        if (enemyDeplacement != null && !touchedEnemies.Contains(enemy))
        {
            enemyDeplacement.slowDeplacement(spell.spellValue, spell.spellTime);
            touchedEnemies.Add(enemy);
        }

    }


}
