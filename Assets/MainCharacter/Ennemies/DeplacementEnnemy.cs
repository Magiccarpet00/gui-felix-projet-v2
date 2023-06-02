using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeplacementEnnemy : MonoBehaviour
{
    NavMeshAgent ennemyAgent;
    public Transform target;

    [SerializeField] float idleDistance = 10f, walkDistance = 7f, attackDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        ennemyAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ennemyAgent.remainingDistance > walkDistance)
        {
            ennemyAgent.speed = 0;

        }
        else 
        {
            ennemyAgent.speed = 1f;

        }


        ennemyAgent.SetDestination(target.position);
    }
}
