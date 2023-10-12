using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class epeeDetection : SpellEffect
{
    public SpellScriptableObject spell;
    public float refreshDammageTime;
    private bool collisionDetected = false; // Variable pour contrôler la détection de collision.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SetSpellColliderEffect(spell, other);
        }

    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Enemy")&& collisionDetected == false)
    //    {
    //        StartCoroutine(detectionCoroutine(other));
    //    }
    //}

    //IEnumerator detectionCoroutine(Collider other)
    //{
    //    collisionDetected = true;
    //    SetSpellColliderEffect(spell, other);
    //    yield return new WaitForSeconds(Time.deltaTime);
    //    collisionDetected = false;

    //}



}

 