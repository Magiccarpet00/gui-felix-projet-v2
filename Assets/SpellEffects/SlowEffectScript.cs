using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffectScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void SlowEffect(SpellScriptableObject spell, Collider enemy)
    {
        DeplacementEnnemy enemyDeplacement = enemy.GetComponent<DeplacementEnnemy>();
        if (enemyDeplacement != null)
        {
            enemyDeplacement.slowDeplacement(spell.spellSlowValue, spell.spellEffectTime);
        }
    }
}
