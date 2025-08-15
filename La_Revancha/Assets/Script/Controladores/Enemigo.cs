using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    public Vector2 patrolArea;
    public float patrolTime;
    public float chaseDistance;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform playerTransform;
    private Vector3 playerPosition;
    private EnemyState enemyState;
    private Vector3 patrolDestination;

   // public GameObject barraVida;
    //public int vida = 100;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("prota").transform;
        enemyState = EnemyState.PATROL;
        InvokeRepeating("CalculatePatrolDestination", 0f, patrolTime);
    }

    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.PATROL:
                /*if (Vector3.Distance(transform.position, playerTransform.position) <= chaseDistance)
                    enemyState = EnemyState.CHASE;
                else
                    navMeshAgent.SetDestination(patrolDestination);*/
                Patrol();
                break;
            case EnemyState.CHASE:
                Chase();
                /*navMeshAgent.SetDestination(playerTransform.position);
                animator.SetFloat("Speed", navMeshAgent.velocity.sqrMagnitude);*/
                break;
            case EnemyState.ATTACK:
                Atack();
                /*if (Vector3.Distance(transform.position, playerTransform.position) >= chaseDistance)
                    animator.SetTrigger("Ataque");*/
                break;
        }
    }

    public void CalculatePatrolDestination()
    {
        patrolDestination = transform.position + new Vector3(Random.Range(-patrolArea.x, patrolArea.x),
                                                            0f,
                                                            Random.Range(-patrolArea.y, patrolArea.y));
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("Contacto con barra");
            PerderVidaEnemigo();
        }
    }
    private void PerderVidaEnemigo()
    {
        vida = vida - 50;
        barraVida.GetComponent<Slider>().value = vida;
        RevisarVida();
    }

    private void RevisarVida()
    {
        if (vida == 0)
        {
            animator.SetTrigger("Morir");
            StartCoroutine(TiempoMuerte());

        }
    }

    private IEnumerator TiempoMuerte()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    */
    private void Patrol()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) <= chaseDistance)
        {
            enemyState = EnemyState.CHASE;
        }
        else
        {
            navMeshAgent.SetDestination(patrolDestination);
            animator.SetFloat("walk", navMeshAgent.velocity.sqrMagnitude);
        }
    }

    private void Chase()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) > chaseDistance)
        {
            enemyState = EnemyState.PATROL;
        }
        else
        {


            if (Vector3.Distance(transform.position, playerTransform.position) <= 5f)
            {
                enemyState = EnemyState.ATTACK;
                Debug.Log("Distancia a 5");
            }
            else
            {
                Debug.Log("Distancia de más de 5");
                navMeshAgent.SetDestination(playerTransform.position);
                animator.SetFloat("speed", navMeshAgent.velocity.sqrMagnitude);
            }
        }
        
    }

    private void Atack()
    {
        navMeshAgent.SetDestination(playerTransform.position);
        animator.SetTrigger("AtaqueEnemigo");
        if (Vector3.Distance(transform.position, playerTransform.position) > 5f)
        {
            enemyState = EnemyState.CHASE;
        }
    }
}

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}


