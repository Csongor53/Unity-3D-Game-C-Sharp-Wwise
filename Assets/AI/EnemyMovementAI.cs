using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementAI : MonoBehaviour
{
    [SerializeField] private int radius;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.velocity == Vector3.zero)
            ChangeTargetPosition();
        transform.position = navMeshAgent.nextPosition;
    }

    private void ChangeTargetPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        Vector3 targetPosition = transform.position + randomDirection;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPosition, out hit, radius, 1))
        {
            navMeshAgent.SetDestination(targetPosition);
        }
    }
}
