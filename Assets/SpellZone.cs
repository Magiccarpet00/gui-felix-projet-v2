using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellZone : MonoBehaviour
{


    bool gizmoSphere = false;
    bool gizmoCone = false;
    bool gizmoRay = false;
    bool gizmoBall = false;

    float attackRange;


    Vector3 mousePos = GameManager.instance.GetMousePos();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SphereAttack(SpellScriptableObject spell)
    {
        gizmoSphere = true;
        gizmoCone = false;
        gizmoRay = false;
        gizmoBall = false;

        attackRange = spell.attackRange;


        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, spell.attackRange);

        foreach (Collider enemy in hitEnemies)
        {

            // Inflige des dégâts à l'ennemi
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(spell.attackDamage);

            }
        }
    }

    public void ConeAttack(SpellScriptableObject spell)
    {
        float coneAngle = 45f;

        gizmoSphere = false;
        gizmoCone = true;
        gizmoRay = false;
        gizmoBall = false;

        attackRange = spell.attackRange;


        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, spell.attackRange);

        foreach (Collider enemy in hitEnemies)
        {
           

            // Check if the collider is within the cone angle
            Vector3 directionToCollider = enemy.transform.position - transform.position;
            float angleToCollider = Vector3.Angle(mousePos, directionToCollider);


            if (angleToCollider < coneAngle)
            {
                // Inflige des dégâts à l'ennemi
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(spell.attackDamage);

                }
            }

        }


    }

    public void RayAttack(SpellScriptableObject spell)
    {
        gizmoSphere = false;
        gizmoCone = false;
        gizmoRay = true;
        gizmoBall = false;

        attackRange = spell.attackRange;

        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit[] hitEnemies = Physics.RaycastAll(ray);

        foreach (RaycastHit enemy in hitEnemies)
        {

            // Inflige des dégâts à l'ennemi
            EnemyHealth enemyHealth = enemy.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(spell.attackDamage);

            }
        }

    }

    public void BallAttack(SpellScriptableObject spell)
    {
        gizmoSphere = false;
        gizmoCone = false;
        gizmoRay = false;
        gizmoBall = true;

        attackRange = spell.attackRange;

        //GameObject areaEffect = Instantiate(ballSpell, transform.position, Quaternion.identity);
        //areaEffect.GetComponent<AreaEffect>().SetUp(spell.attackDamage, spell.spellTime);

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
            float coneDirection = 90;

            Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV - coneDirection, transform.up);
            Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV - coneDirection, transform.up);

            Vector3 leftRayDirection = leftRayRotation * transform.right * attackRange;
            Vector3 rightRayDirection = rightRayRotation * transform.right * attackRange;

            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, leftRayDirection);
            Gizmos.DrawRay(transform.position, rightRayDirection);
            Gizmos.DrawLine(transform.position + leftRayDirection, transform.position + rightRayDirection);

        }
        else if (gizmoRay == true)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction * attackRange);
        }

    }
}
