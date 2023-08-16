using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellZone : SpellEffect
{


    bool gizmoSphere = false;
    bool gizmoCone = false;
    bool gizmoRay = false;

    float attackRange;


    Vector3 mousPosLocalPlayer;
    Vector3 mousPosworld;
    Vector3 interpolatePos;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sphere(SpellScriptableObject spell)
    {
        gizmoSphere = true;
        gizmoCone = false;
        gizmoRay = false;

        attackRange = spell.attackRange;

        mousPosLocalPlayer = GameManager.instance.GetMousePosLocal(transform);

        StartCoroutine(SphereDetectColisionInTime(spell));

        if (spell.spellEffect == "Blink")
        {
            BlinkEffect(spell, interpolatePos);
        }

    }

    public void Cone(SpellScriptableObject spell)
    {
        

        gizmoSphere = false;
        gizmoCone = true;
        gizmoRay = false;

        attackRange = spell.attackRange;

        mousPosLocalPlayer = GameManager.instance.GetMousePosLocal(transform);

        StartCoroutine(ConeDetectColisionInTime(spell));

        if (spell.spellEffect == "Blink")
        {
            BlinkEffect(spell, interpolatePos);
        }


    }

    public void Ray(SpellScriptableObject spell)
    {
        gizmoSphere = false;
        gizmoCone = false;
        gizmoRay = true;

        attackRange = spell.attackRange;

        mousPosLocalPlayer = GameManager.instance.GetMousePosLocal(transform);
        mousPosworld = GameManager.instance.GetMousePosWorld(transform);
        interpolatePos = GameManager.instance.InterpolatePoints(transform.position, mousPosworld, spell.spellValue);

        StartCoroutine(RayDetectColisionInTime(spell));

        if (spell.spellEffect == "Blink")
        {
            BlinkEffect(spell, interpolatePos);
        }

    }


    IEnumerator SphereDetectColisionInTime(SpellScriptableObject spell)
    {

        while (true)
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange);

            foreach (Collider enemy in hitEnemies)
            {
                SetSpellActiveEffect(spell, enemy);
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
                    SetSpellActiveEffect(spell, enemy);
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

            RaycastHit[] hitEnemies = Physics.RaycastAll(ray, attackRange);

            foreach (RaycastHit enemy in hitEnemies)
            {
                if (spell.spellEffect == "Dommage")
                {
                    // Inflige des dégâts à l'ennemi
                    DammageEffect(spell, enemy.collider);

                }
                else if (spell.spellEffect == "Slow")
                {
                    // Ralenti la cible
                    SlowEffect(spell, enemy.collider);
                }

            }
            
            yield return null;
        }
    }


        private void OnDrawGizmos()
    {

        if (gizmoSphere == true)
        {// Dessine une sphère pour représenter la portée d'attaque dans l'éditeur
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
        else if (gizmoCone == true)
        {
            //Gizmo cone parameter
            float angle = 45f;
            float halfFOV = angle / 2.0f;
            

            Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, transform.up);
            Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, transform.up);

            Vector3 leftRayDirection = leftRayRotation *  Vector3.Normalize(mousPosLocalPlayer) * attackRange;
            Vector3 rightRayDirection = rightRayRotation * Vector3.Normalize(mousPosLocalPlayer) * attackRange;

            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, leftRayDirection);
            Gizmos.DrawRay(transform.position, rightRayDirection);
            Gizmos.DrawLine(transform.position + leftRayDirection, transform.position + rightRayDirection);

        }
        else if (gizmoRay == true)
        {
            Ray ray = new Ray(transform.position, mousPosLocalPlayer);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction * attackRange);
        }

    }
}
