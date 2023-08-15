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


    Vector3 mousPosLocalPlayer;

    private HashSet<Collider> touchedEnemies = new HashSet<Collider>();


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

        mousPosLocalPlayer = GameManager.instance.GetMousePosLocal(transform);

        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, spell.attackRange);

        foreach (Collider enemy in hitEnemies)
        {


            // Check si le collider est dans le cone angle
            Vector3 directionToCollider = enemy.transform.position - transform.position;
            float angleToCollider = Vector3.Angle(mousPosLocalPlayer, directionToCollider);


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

        mousPosLocalPlayer = GameManager.instance.GetMousePosLocal(transform);
        Ray ray = new Ray(transform.position, Vector3.Normalize(mousPosLocalPlayer));
       

        RaycastHit[] hitEnemies = Physics.RaycastAll(ray,attackRange);

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
        gizmoSphere = true;
        gizmoCone = false;
        gizmoRay = false;

        attackRange = spell.attackRange;


        StartCoroutine(DetectColisionBall(spell));
    }

    IEnumerator DetectColisionBall(SpellScriptableObject spell)
    {

        while (true)
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange);

            foreach (Collider enemy in hitEnemies)
            {
                    // Inflige des dégâts à l'ennemi
                    EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                    if (enemyHealth != null && !touchedEnemies.Contains(enemy))
                    {
                        enemyHealth.TakeDamage(spell.attackDamage);
                        touchedEnemies.Add(enemy);
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
