using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell2 : MonoBehaviour
{
    public SpellData2 spellData;
    public Character owner;
    
    public Rigidbody rb;



    private Vector3 initialMousePos;


    public virtual void Load() {;}
    public virtual void Cast() {;}
    public virtual void OnTriggerEnter(Collider other) {;}
    public virtual void Effect() {;}



    public void SendSetting(Vector3 mousePos, GameObject _owner)
    {
        initialMousePos = mousePos;
        owner = _owner.GetComponent<Character>();
    }

    public bool isInRange(Vector3 origin, Vector3 mousePos)
    {
        if (spellData.range == 0) return true;

        float dist = Vector3.Distance(origin, mousePos);

        if (dist <= spellData.range)
            return true;
        else
            return false;
    }




    /*-----------------------------*/
    //      SPELL TOOL BOX
    /*-----------------------------*/
    public void _LoadCancelMove(float time)
    {
        StartCoroutine(LoadCancelMove(time));
        
    }

    public IEnumerator LoadCancelMove(float time)
    {
        Debug.Log("pote");
        float tmp = owner.navMeshAgent.speed;
        owner.navMeshAgent.speed = 0;
        yield return new WaitForSeconds(time);
        owner.navMeshAgent.speed = tmp;
        Cast();
    }


    public void LinearSkillShotCast()
    {
        AddRigidBody();
        Vector3 dir = initialMousePos - owner.transform.position;
        rb.AddForce(dir.normalized * spellData.speed, ForceMode.Impulse);
    }

    public void AddRigidBody()
    {
        rb = this.gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
}
