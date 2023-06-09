using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public SpellData spellData;
    public GameObject owner;
    public Rigidbody rb;

    public List<GameObject> targets;

    public void Cast(Vector3 mousePos, GameObject owner)
    {
        switch (spellData.castType)
        {
            case Spell_CastType.TARGET:
                AddRigidBody();
                transform.SetPositionAndRotation(mousePos, Quaternion.identity);
                break;

            case Spell_CastType.SKILL_SHOT:
                AddRigidBody();
                Vector3 dir = mousePos - owner.transform.position;
                rb.AddForce(dir.normalized * spellData.speed, ForceMode.Impulse);
                break;

            case Spell_CastType.SELF:
                targets.Add(owner);
                ApplyEffect();
                break;

            case Spell_CastType.PASSIF:
                targets.Add(owner);
                ApplyEffect();
                break;

        }

        GameObject model = Instantiate(spellData.model, transform.position, Quaternion.identity);
        model.transform.SetParent(this.transform);

        StartCoroutine(Life());
    }

    
    private void OnTriggerEnter(Collider other)
    {
        string tag = string.Empty;
        switch (spellData.target)
        {
            case Spell_Target.SELF:
                tag = "Player";
                break;

            case Spell_Target.ALLY:
                tag = "Ally";
                break;

            case Spell_Target.ENEMY:
                tag = "Enemy";
                break;
        }

        if(other.gameObject.CompareTag(tag))
        {
            targets.Add(other.gameObject);
            ApplyEffect();
        }
        
    }

    public void AddRigidBody()
    {
        rb = this.gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public IEnumerator Life()
    {
        yield return new WaitForSeconds(spellData.lifeTime);

        if(spellData.lifeTime != 0)
            Destroy(this.gameObject);
    }

    public void ApplyEffect()
    {
        switch(spellData.effect)
        {
            case Spell_Effect.BUFF_DEBUFF:
                break;

            case Spell_Effect.DOMAGE_HEAL:
                foreach (GameObject t in targets)
                {
                    t.GetComponent<Character>().TakeDamage(spellData.damage);
                }
                break;

            case Spell_Effect.INVOKE:
                break;

            case Spell_Effect.MOVE:
                foreach (GameObject t in targets)
                {
                    Vector3 dir = Vector3.zero;
                    if (spellData.bump_Dir == Bump_Dir.CENTER)
                        dir = t.transform.position - this.transform.position;

                    if(spellData.bump_Dir == Bump_Dir.MOUSE)
                        dir = GameManager.instance.GetMousePos() - this.transform.position;

                    t.GetComponent<PlayerDeplacement>()._Bump(spellData.bump_time, spellData.bump_velocity, dir);
                }
                break;
        }
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

public enum Bump_Dir
{
    MOUSE,
    CENTER
}