using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DotEffectScript : MonoBehaviour
{
    public void DotEffect(SpellScriptableObject spell, Collider enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        PlayerHealth playerHealth = enemy.GetComponent<PlayerHealth>();
        TextMeshProUGUI tmp = enemy.GetComponentInChildren<TextMeshProUGUI>();

        if (enemyHealth != null)
        {
            
            enemyHealth.TakeDamageOnTime(spell.spellDotValue, spell.spellDotLifeTime, spell.spellEffectTime, spell.spellID);

            //StartCoroutine(HotActiveTime(tmp, spell.spellEffectTime));

        }
        if(playerHealth != null)
        {
            playerHealth.TakeDamageOnTime(spell.spellDotValue, spell.spellDotLifeTime, spell.spellEffectTime, spell.spellID);
        }
    }

    IEnumerator HotActiveTime (TextMeshProUGUI tmp, float spellTime)
    {
        tmp.color = Color.red;
        yield return new WaitForSeconds(spellTime);
        tmp.color = Color.white;

    }





}
