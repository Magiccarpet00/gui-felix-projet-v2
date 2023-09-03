using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DammageEffectScript : MonoBehaviour
{
        
    public void DammageEffect(SpellScriptableObject spell, Collider enemy)
    {
       
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        StartCoroutine(DammageTic(spell.spellTime, enemyHealth, enemy, spell));

    }

    IEnumerator DammageTic(float time, EnemyHealth enemyHealth, Collider enemy, SpellScriptableObject spell)
    {
        while(enemyHealth != null)
        {
                enemyHealth.TakeDamage(spell.spellValue);

            yield return new WaitForSeconds(time);
        }
       
    }
}
