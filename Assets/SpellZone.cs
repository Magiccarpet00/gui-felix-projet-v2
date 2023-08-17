using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellZone : SpellEffect
{


    bool gizmoSphereSpell = false;
    bool gizmoConeSpell = false;
    bool gizmoRaySpell = false;

    bool gizmoSphereMegaSpell = false;
    bool gizmoConeMegaSpell = false;
    bool gizmoRayMegaSpell = false;

    float attackRange;


    Vector3 mousPosLocalPlayer;
    Vector3 mousPosworld;
    Vector3 interpolatePos;


    public void Sphere(SpellScriptableObject spell)
    {
        if(GameManager.instance.isCastingMegaSpell == false)
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
        interpolatePos = GameManager.instance.InterpolatePoints(transform.position, mousPosworld, spell.spellValue);

        StartCoroutine(SphereDetectColisionInTime(spell));
        SetSpellNoColliderEffect(spell, interpolatePos);


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
        interpolatePos = GameManager.instance.InterpolatePoints(transform.position, mousPosworld, spell.spellValue);

        StartCoroutine(ConeDetectColisionInTime(spell));
        SetSpellNoColliderEffect(spell, interpolatePos);




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
        interpolatePos = GameManager.instance.InterpolatePoints(transform.position, mousPosworld, spell.spellValue);

        StartCoroutine(RayDetectColisionInTime(spell));
        SetSpellNoColliderEffect(spell, interpolatePos);


    }


    IEnumerator SphereDetectColisionInTime(SpellScriptableObject spell)
    {

        while (true)
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange);

            foreach (Collider enemy in hitEnemies)
            {
                SetSpellColliderEffect(spell, enemy);
            }



            yield return null; 
        }
    }

    IEnumerator ConeDetectColisionInTime(SpellScriptableObject spell)
    {

        while (true)
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, spell.attackRange);
            float coneAngle = 45f;
            foreach (Collider enemy in hitEnemies)
            {

                // Check si le collider est dans le cone angle
                Vector3 directionToCollider = enemy.transform.position - transform.position;
                float angleToCollider = Vector3.Angle(mousPosLocalPlayer, directionToCollider);


                if (angleToCollider < coneAngle)
                {
                    SetSpellColliderEffect(spell, enemy);
                }

            }


            yield return null;
        }
    }

    IEnumerator RayDetectColisionInTime(SpellScriptableObject spell)
    {

        while (true)
        {
            Ray ray = new Ray(transform.position, Vector3.Normalize(mousPosLocalPlayer));

            RaycastHit[] hitRayEnemies = Physics.RaycastAll(ray, attackRange);
            Collider[] hitEnemies = new Collider[hitRayEnemies.Length];

            for (int i = 0; i < hitRayEnemies.Length; i++)
            {
                hitEnemies[i] = hitRayEnemies[i].collider;
            }

            foreach (Collider enemy in hitEnemies)
            {
                SetSpellColliderEffect(spell, enemy);
            }


            yield return null;
        }
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

            Vector3 leftRayDirection = leftRayRotation * Vector3.Normalize(mousPosLocalPlayer) * attackRange;
            Vector3 rightRayDirection = rightRayRotation * Vector3.Normalize(mousPosLocalPlayer) * attackRange;

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

            Vector3 leftRayDirection = leftRayRotation * Vector3.Normalize(mousPosLocalPlayer) * attackRange;
            Vector3 rightRayDirection = rightRayRotation * Vector3.Normalize(mousPosLocalPlayer) * attackRange;

            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, leftRayDirection);
            Gizmos.DrawRay(transform.position, rightRayDirection);
            Gizmos.DrawLine(transform.position + leftRayDirection, transform.position + rightRayDirection);
        }
        else if (gizmoRaySpell == true)
        {
            Ray ray = new Ray(transform.position, mousPosLocalPlayer);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction * attackRange);
        }
        else if(gizmoRayMegaSpell == true)
        {
            Ray ray = new Ray(transform.position, mousPosLocalPlayer);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(ray.origin, ray.direction * attackRange);

        }

    }
}
