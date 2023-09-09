using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DammageEffectScript : MonoBehaviour
{
        
    public void DammageEffect(SpellScriptableObject spell, Collider enemy)
    {
        Debug.Log("Dammage");
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyHealth.TakeDamage(spell.spellValue);

    }

    
}
