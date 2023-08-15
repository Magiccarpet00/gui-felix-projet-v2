using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpellEffect : MonoBehaviour
{


    public List<Collider> listTouchedEnemies = new List<Collider>();
    
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


    }





}
