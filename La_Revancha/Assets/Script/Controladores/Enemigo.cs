using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public Vector2 patrolArea;
    public float patrolRefreshTime;
    private NavMeshAgent agent;
    private GameObject player;
    private Animator animator;
    private EnemyState currentState;
    private Vector3 destination;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("prota");
        animator = GetComponent<Animator>();
        ChangeState(EnemyState.PATROL);
        //currentState = GetComponent<EnemyState>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination);
        animator.SetFloat("speed", agent.velocity.sqrMagnitude);
        ChangeState(EnemyState.PATROL);
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
