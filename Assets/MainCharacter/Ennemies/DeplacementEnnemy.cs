using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeplacementEnnemy : MonoBehaviour
{
    public NavMeshAgent ennemyAgent;
    public Transform target;
    public float ennemyAgentWlakingSpeed =1f;

    [SerializeField] float walkDistance = 7f, attackDistance = 1f; // ajouter une variable idleDistance = 10f pour l'animation d'idle

    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(delayTricks());
    }

    public IEnumerator delayTricks() //pas super important le petit delay
    {
        yield return new WaitForSeconds(1);
        //ennemyAgent.SetDestination(new Vector3(0,0,0));
        ennemyAgent.SetDestination(target.position);
        StartCoroutine(delayTricks());
    }

    void Update()
    {
        if (ennemyAgent.remainingDistance > walkDistance || ennemyAgent.remainingDistance < attackDistance)
        {
            ennemyAgent.speed = 0;
        }
        else
        {
            ennemyAgent.speed = ennemyAgentWlakingSpeed;
        }

    }

    public void slowDeplacement(float spellValue, float spellTime)
    {
        StartCoroutine(ReduceEnnemySpeed(spellValue, spellTime));
    }

    IEnumerator ReduceEnnemySpeed(float spellValue, float time)
    {
        ennemyAgentWlakingSpeed = ennemyAgentWlakingSpeed - spellValue;

            yield return new WaitForSeconds(time);

        ennemyAgentWlakingSpeed = ennemyAgentWlakingSpeed + spellValue;
    }
}
