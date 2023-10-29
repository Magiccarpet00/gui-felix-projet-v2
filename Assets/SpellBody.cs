using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBody : MonoBehaviour
{
    public GameObject instantiatedSpellBody;
    public ParticleSystem instantiatedSpellBodyParticleSystem;
    public Transform ownerSpellZone;


    public void SpellBodyDisplay(SpellScriptableObject spell)
    {
        instantiatedSpellBody = Instantiate(spell.spellBody,transform);
        instantiatedSpellBody.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        instantiatedSpellBodyParticleSystem = instantiatedSpellBody.GetComponent<ParticleSystem>();

        if (spell.spellZone == "Ray")
        {
            instantiatedSpellBody.transform.localScale = new Vector3(0, 0, spell.attackRange);
        }
        if (spell.spellZone == "Sphere")
        {
            
        }   

        if (instantiatedSpellBodyParticleSystem != null)
        {
            var mainModule = instantiatedSpellBodyParticleSystem.main;
            mainModule.startSpeed = spell.attackRange;
        }
       
    }
}
