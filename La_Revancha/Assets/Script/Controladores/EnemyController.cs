using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Vector2 patrolArea;
    public float patrolRefreshTime;
    private NavMeshAgent agent;
    private GameObject player;
    private Animator animator;
    private Vector3 destination;

    private EnemyState currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("prota");
        animator = GetComponent<Animator>();
        ChangeState(EnemyState.PATROL);
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(player.transform.position);
        agent.SetDestination(destination);
        animator.SetFloat("VelX", agent.velocity.sqrMagnitude);
    }

    public void ChangeState(EnemyState newState)
    {
        switch (newState)
        {
            case EnemyState.PATROL:
                StartCoroutine("WaitToNewPatrolPoint");
                break;
            case EnemyState.CHASE:
                destination = player.transform.position;
                break;
            case EnemyState.ATACK:
                break;
        }
        currentState = newState;

    }

    IEnumerator WaitToNewPatrolPoint()
    {
        while (currentState == EnemyState.PATROL)
        {
            destination = transform.position + new Vector3(Random.Range(-patrolArea.x, patrolArea.x), 0f, Random.Range(-patrolArea.y, patrolArea.y));
            yield return new WaitForSeconds(patrolRefreshTime);
        }

    }
}

public enum EnemyState
{
    PATROL,
    CHASE,
    ATACK
}
