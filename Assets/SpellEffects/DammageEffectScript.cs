using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DammageEffectScript : MonoBehaviour
{
        
    public void DammageEffect(SpellScriptableObject spell, Collider enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        PlayerHealth playerHealth = enemy.GetComponent<PlayerHealth>();

        if(enemyHealth != null)
        {
            enemyHealth.TakeDamage(spell.spellDommageValue);

        }

        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(spell.spellDommageValue);

        }

    }

    
}
