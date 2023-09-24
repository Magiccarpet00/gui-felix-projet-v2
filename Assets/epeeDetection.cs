using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class epeeDetection : SpellEffect
{
    public SpellScriptableObject spell;
    private bool collisionDetected = false; // Variable pour contrôler la détection de collision.

    private void OnTriggerEnter(Collider enemy)
    {

        if (!collisionDetected)
        {
            if (enemy.tag == "Enemy")
            {
                Debug.Log("coucou");
                SetSpellColliderEffect(spell, enemy);
            }
            collisionDetected = true;
            StartCoroutine(OneMiliSecond());
        }

    }

    IEnumerator OneMiliSecond()
    {
        yield return new WaitForSeconds(0.2f);
        collisionDetected = false;


    }


}

 