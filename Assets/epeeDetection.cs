using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class epeeDetection : SpellEffect
{
    public SpellScriptableObject spell;

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.tag == "Enemy")
        {
            SetSpellColliderEffect(spell, enemy);
        }

    }
}

   