using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DammageEffectScript : MonoBehaviour
{
    public void DammageEffect(SpellScriptableObject spell, Collider enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if(enemyHealth != null)
        {
            enemyHealth.TakeDamage(spell.spellValue);

        }
          

    }
}
