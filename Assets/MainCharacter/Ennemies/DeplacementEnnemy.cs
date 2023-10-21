using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeplacementEnnemy : MonoBehaviour
{
    public NavMeshAgent ennemyAgent;
    public Transform target;
    [SerializeField] float walkingSpeed;
    public bool isSlowed = false;
    public bool hasDetectedPlayer;

    [SerializeField] float walkDistance , attackDistance; // ajouter une variable idleDistance = 10f pour l'animation d'idle

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
        if (ennemyAgent.remainingDistance > walkDistance)
        {
            ennemyAgent.speed = 0;
            hasDetectedPlayer = false;
        }
        if (ennemyAgent.remainingDistance < walkDistance)
        {
            ennemyAgent.speed = walkingSpeed;
            hasDetectedPlayer = true;
        }

        if (ennemyAgent.remainingDistance < attackDistance)
        {
            ennemyAgent.speed = 0;
            hasDetectedPlayer = true;
        }
       

    }

    public void slowDeplacement(float spellValue, float spellTime)
    {
        if(isSlowed == false)
        {
            StartCoroutine(ReduceEnnemySpeed(spellValue, spellTime));
        }
    }

    IEnumerator ReduceEnnemySpeed(float spellValue, float time)
    {
        walkingSpeed = walkingSpeed - spellValue;
        isSlowed = true;

            yield return new WaitForSeconds(time);

        walkingSpeed = walkingSpeed + spellValue;
        isSlowed = false;
    }
}
