using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DotEffectScript : MonoBehaviour
{
    private bool coroutineEnCours = false;


    public void DotEffect(SpellScriptableObject spell, Collider enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        TextMeshProUGUI tmp = enemy.GetComponentInChildren<TextMeshProUGUI>();
        if (enemyHealth != null && !coroutineEnCours)
        { 
            
                StartCoroutine(HotActiveTime(tmp, spell.spellEffectTime));
               
        }
    }

    IEnumerator HotActiveTime (TextMeshProUGUI tmp, float spellTime)
    {
        coroutineEnCours = true;
        tmp.color = Color.red;  
        yield return new WaitForSeconds(spellTime);
        tmp.color = Color.white;
        coroutineEnCours = false;
    }





}
