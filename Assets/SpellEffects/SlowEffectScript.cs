using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffectScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void SlowEffect(SpellScriptableObject spell, Collider enemy)
    {
        DeplacementEnnemy enemyDeplacement = enemy.GetComponent<DeplacementEnnemy>();
        PlayerDeplacement playerDeplacement = enemy.GetComponent<PlayerDeplacement>();
       
        if (enemyDeplacement != null)
        {
            enemyDeplacement.slowDeplacement(spell.spellSlowValue, spell.spellEffectTime);
        }
        if (playerDeplacement != null)
        {
            Debug.Log("Lancement du slow dans le player");
            playerDeplacement.slowDeplacement(spell.spellSlowValue, spell.spellEffectTime);
        }
    }
}
