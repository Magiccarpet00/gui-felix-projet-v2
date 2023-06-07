using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public SpellData spellData;
    public GameObject owner;
    public Rigidbody rb;

    public void Cast(Vector3 mousePos, GameObject owner)
    {
        switch (spellData.castType)
        {
            case Spell_CastType.TARGET:                
                transform.SetPositionAndRotation(mousePos, Quaternion.identity);
                break;

            case Spell_CastType.SKILL_SHOT:
                rb = this.gameObject.AddComponent<Rigidbody>();
                rb.useGravity = false;
                Vector3 dir = mousePos - owner.transform.position;
                rb.AddForce(dir.normalized * spellData.speed, ForceMode.Impulse);
                break;
        }

        GameObject model = Instantiate(spellData.model, transform.position, Quaternion.identity);
        model.transform.SetParent(this.transform);

        StartCoroutine(Life());
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public IEnumerator Life()
    {
        yield return new WaitForSeconds(spellData.lifeTime);
        Destroy(this.gameObject);
    }




}

public enum Spell_CastType
{
    TARGET,     // Instantiate sur mouse
    SKILL_SHOT, // Instantiate sur owner -> move to dir
    SELF,
    PASSIF
}

public enum Spell_Target
{
    SELF,
    ALLY,
    ENEMY
}

public enum Spell_Effect
{
    BUFF_DEBUFF,
    DOMAGE_HEAL,
    MOVE,
    INVOKE //On peut instantiat un autre spell pour reaction en chaine
}
