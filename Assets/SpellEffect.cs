using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpellEffect : MonoBehaviour
{
    
    //---------Définition des combinaisons d'effets--------------

    public void SetSpellColliderEffect(SpellScriptableObject spell, Collider enemy) //Blink n'est pas dans cette méthode 
    {
        foreach (string spellEffect in spell.spellEffect)
        {
            if (spellEffect == "Dommage")
            {
                GameManager.instance.dammageEffectScript.DammageEffect(spell,enemy);
            }
            if (spellEffect == "Slow")
            {
                GameManager.instance.slowEffectScript.SlowEffect(spell, enemy);
            }

        }
    
    }

    public void SetSpellNoColliderEffect(SpellScriptableObject spell, Vector3 interpolatePos)
    {
        for (int i = 0; i < spell.spellEffect.Count; i++)
        {
            if (spell.spellEffect[i] == "Blink")
            {
                GameManager.instance.blinkEffectScript.BlinkEffect(spell, interpolatePos);
            }
        }
           
    }

    }




