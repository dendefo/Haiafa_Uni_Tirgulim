using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationEnemyController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] PlayerController playerController;
    [SerializeField] List<Transform> patrolPoints;
    [SerializeField] float SeeingDistance = 10f;
    [SerializeField] bool isDetected;

    void Update()
    {
        if ((transform.position - playerController.transform.position).magnitude < SeeingDistance && isDetected)
        {
            navMeshAgent.SetDestination(playerController.transform.position);
        }
        else
        {
            Patrol();
        }

        animator.SetFloat("Move Speed", navMeshAgent.velocity.magnitude);

        animator.SetFloat("Direction", (transform.rotation * navMeshAgent.velocity.normalized).x);

        if (navMeshAgent.isOnOffMeshLink)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

    }

    private void Patrol()
    {
        if (patrolPoints.Count == 0) return;
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            int nextPointIndex = UnityEngine.Random.Range(0, patrolPoints.Count);
            navMeshAgent.SetDestination(patrolPoints[nextPointIndex].position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isDetected = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isDetected = false;
    }
}
