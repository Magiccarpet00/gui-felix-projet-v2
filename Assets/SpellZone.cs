using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpellZone : SpellEffect
{
    bool gizmoSphereSpell = false;
    bool gizmoConeSpell = false;
    bool gizmoRaySpell = false;
    bool gizmoAllongeSpell = false;


    bool gizmoSphereMegaSpell = false;
    bool gizmoConeMegaSpell = false;
    bool gizmoRayMegaSpell = false;
    bool gizmoAllongeMegaSpell = false;


    float attackRange;


    Vector3 mousPosLocalPlayer;
    Vector3 mousPosworld;
    Vector3 mousPos;
    Vector3 interpolatePos;
    Vector3 spellDirection;

    public bool isCastedByEnnemy = false;

    public Transform ownerSpellZone;
   
    public float lerpSpeed = 0.5f;

    private float t = 0.0f;

    private void Awake()
    {


       

    }

    private void Start()
    {

        spellDirection = ownerSpellZone.forward;

    }

    public void Update()
    {
        spellDirection = ownerSpellZone.forward;

        t += lerpSpeed * Time.deltaTime;
        t = Mathf.Clamp01(t);
    }

    public void Sphere(SpellScriptableObject spell)
    {
        if (GameManager.instance.isCastingMegaSpell == false)
        {

            gizmoSphereSpell = true;
            gizmoConeSpell = false;
            gizmoRaySpell = false;
        }
        else if (GameManager.instance.isCastingMegaSpell == true)
        {
            gizmoSphereMegaSpell = true;
            gizmoConeMegaSpell = false;
            gizmoRayMegaSpell = false;
        }


        attackRange = spell.attackRange;

        mousPosLocalPlayer = GameManager.instance.GetMousePosLocal(transform);
        mousPosworld = GameManager.instance.GetMousePosWorld(transform);
        //interpolatePos = GameManager.instance.InterpolatePoints(transform.position, mousPosworld, spell.spellValue);

        SetSpellNoColliderEffect(spell, mousPosworld);

        StartCoroutine(DetectEnnemiesInSphere(spell));



    }

    IEnumerator DetectEnnemiesInSphere(SpellScriptableObject spell)
    {
        while (true)
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange);

            foreach (Collider enemy in hitEnemies)
            {

                if (enemy.tag == "Enemy" && ownerSpellZone.tag != "Enemy")
                {
                    SetSpellColliderEffect(spell, enemy);
                }
                if (enemy.tag == "Player" && ownerSpellZone.tag != "Player")
                {
                    SetSpellColliderEffect(spell, enemy);
                }

            }

            yield return new WaitForSeconds(spell.refreshSpellZoneTime);

        }
    }

    public void Cone(SpellScriptableObject spell)
    {
        if (GameManager.instance.isCastingMegaSpell == false)
        {
            gizmoSphereSpell = false;
            gizmoConeSpell = true;
            gizmoRaySpell = false;
        }
        else if (GameManager.instance.isCastingMegaSpell == true)
        {
            gizmoSphereMegaSpell = false;
            gizmoConeMegaSpell = true;
            gizmoRayMegaSpell = false;
        }

        attackRange = spell.attackRange;

        mousPosLocalPlayer = GameManager.instance.GetMousePosLocal(transform);
        mousPosworld = GameManager.instance.GetMousePosWorld(transform);
        //interpolatePos = GameManager.instance.InterpolatePoints(transform.position, mousPosworld, spell.spellValue);

        SetSpellNoColliderEffect(spell, mousPosworld);

        StartCoroutine(DetectEnnemiesInCone(spell));



    }

    IEnumerator DetectEnnemiesInCone(SpellScriptableObject spell)
    {

        while (true)
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, spell.attackRange);

            float coneAngle = 45f;

            foreach (Collider enemy in hitEnemies)
            {
                // Check si le collider est dans le cone angle
                Vector3 directionToCollider = enemy.transform.position - transform.position;

                float angleToCollider = Vector3.Angle(spellDirection, directionToCollider);


                if (angleToCollider < coneAngle && directionToCollider.magnitude < spell.attackRange && enemy.tag == "Enemy" && ownerSpellZone.tag != "Enemy")
                {
                    SetSpellColliderEffect(spell, enemy);
                }
                if (angleToCollider < coneAngle && directionToCollider.magnitude < spell.attackRange && enemy.tag == "Player" && ownerSpellZone.tag != "Player")
                {
                    SetSpellColliderEffect(spell, enemy);
                }
            }

            yield return new WaitForSeconds(spell.refreshSpellZoneTime);

        }
    }

    public void Ray(SpellScriptableObject spell)
    {

        if (GameManager.instance.isCastingMegaSpell == false)
        {
            gizmoSphereSpell = false;
            gizmoConeSpell = false;
            gizmoRaySpell = true;
        }
        else if (GameManager.instance.isCastingMegaSpell == true)
        {
            gizmoSphereMegaSpell = false;
            gizmoConeMegaSpell = false;
            gizmoRayMegaSpell = true;
        }

        attackRange = spell.attackRange;

        mousPosLocalPlayer = GameManager.instance.GetMousePosLocal(transform);
        mousPosworld = GameManager.instance.GetMousePosWorld(transform);

        SetSpellNoColliderEffect(spell, mousPosworld);
        StartCoroutine(DetectEnnemiesInRay(spell));

    }

    IEnumerator DetectEnnemiesInRay(SpellScriptableObject spell)
    {
        while (true)
        {
            Ray ray = new Ray(transform.position, spellDirection);
            RaycastHit[] hits = Physics.RaycastAll(ray);
          
            foreach (RaycastHit hit in hits)
            {
                Collider enemy = hit.collider;

                if (enemy.tag == "Enemy" && ownerSpellZone.tag != "Enemy")
                {
                    SetSpellColliderEffect(spell, enemy);
                }
                if (enemy.tag == "Player" && ownerSpellZone.tag != "Player")
                {
                    
                    SetSpellColliderEffect(spell, enemy);
                }
            }

            yield return new WaitForSeconds(spell.refreshSpellZoneTime);

            
        }
    }

    public void Allonge(SpellScriptableObject spell)
    {
        GameManager.instance.epeeDetection.spell = spell;

        if (!spell.spellEffect.Any(v => v == "Blink" || v == "Dash") && ownerSpellZone.tag != "Enemy")
        {
            GameManager.instance.epeeAnimator.SetBool("epeecoup", !GameManager.instance.epeecoup);
            GameManager.instance.epeecoup = !GameManager.instance.epeecoup;
        }
        mousPosLocalPlayer = GameManager.instance.GetMousePosLocal(transform);
        mousPosworld = GameManager.instance.GetMousePosWorld(transform);
        

        SetSpellNoColliderEffect(spell, mousPosworld);

    }

    public void NoZone(SpellScriptableObject spell)
    {

        attackRange = spell.attackRange;

        mousPosLocalPlayer = GameManager.instance.GetMousePosLocal(transform);
        mousPosworld = GameManager.instance.GetMousePosWorld(transform);

        SetSpellNoColliderEffect(spell, mousPosworld);

        StartCoroutine(DetectEnnemiesInSphere(spell));

    }


    private void OnDrawGizmos()
    {

        if (gizmoSphereSpell == true)
        {// Dessine une sphère pour représenter la portée d'attaque dans l'éditeur
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
        else if (gizmoSphereMegaSpell == true)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
        else if (gizmoConeSpell == true)
        {
            //Gizmo cone parameter
            float angle = 45f;
            float halfFOV = angle / 2.0f;


            Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, transform.up);
            Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, transform.up);

            Vector3 leftRayDirection = leftRayRotation * Vector3.Normalize(spellDirection) * attackRange;
            Vector3 rightRayDirection = rightRayRotation * Vector3.Normalize(spellDirection) * attackRange;

            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, leftRayDirection);
            Gizmos.DrawRay(transform.position, rightRayDirection);
            Gizmos.DrawLine(transform.position + leftRayDirection, transform.position + rightRayDirection);

        }
        else if (gizmoConeMegaSpell == true)
        {//Gizmo cone parameter
            float angle = 45f;
            float halfFOV = angle / 2.0f;


            Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, transform.up);
            Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, transform.up);

            Vector3 leftRayDirection = leftRayRotation * Vector3.Normalize(spellDirection) * attackRange;
            Vector3 rightRayDirection = rightRayRotation * Vector3.Normalize(spellDirection) * attackRange;

            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, leftRayDirection);
            Gizmos.DrawRay(transform.position, rightRayDirection);
            Gizmos.DrawLine(transform.position + leftRayDirection, transform.position + rightRayDirection);
        }
        else if (gizmoRaySpell == true)
        {
            Ray ray = new Ray(transform.position, spellDirection);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction * attackRange);
        }
        else if (gizmoRayMegaSpell == true)
        {
            Ray ray = new Ray(transform.position, spellDirection);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(ray.origin, ray.direction * attackRange);

        }
        else if (gizmoAllongeSpell == true)
        {
            float angle = 45f;
            float halfFOV = angle / 2.0f;


            Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, transform.up);
            Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, transform.up);

            Vector3 leftRayDirection = leftRayRotation * Vector3.Normalize(spellDirection) * attackRange;
            Vector3 rightRayDirection = rightRayRotation * Vector3.Normalize(spellDirection) * attackRange;

            Vector3 lerpedVector = Vector3.Lerp(leftRayDirection, rightRayDirection, t);

            Ray ray = new Ray(transform.position, lerpedVector);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction * attackRange);

        }
        else if (gizmoAllongeMegaSpell == true)
        {

        }

    }
}

    
