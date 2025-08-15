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

    //public GameObject sliderLife;
    public int typeEnemy;
    public Image sliderLife;
    public int life = 100;
    public int attack = 10;
    private float currentLife;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("prota").transform;
        enemyState = EnemyState.PATROL;
        InvokeRepeating("CalculatePatrolDestination", 0f, patrolTime);
        currentLife = life;
    }

    void Update()
    {
       //StatusLife();
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("prota"))
        {
            Debug.Log("Contacto con barra");
            //SoundSFxMuerto.InstanceSFxMuerto.RecibeAtaque();
            //StartCoroutine(TiempoDano());
            PerderVidaEnemigo();
        }
    }
    private void PerderVidaEnemigo()
    {
        //vida = vida - 50;
        currentLife -= attack;
        sliderLife.fillAmount = currentLife / life;
        //sliderLife.GetComponent<Slider>().value = currentLife;
        RevisarVida();
    }

    private void RevisarVida()
    {
        if (currentLife == 0)
        {
            //SoundSFxMuerto.InstanceSFxMuerto.
            animator.SetTrigger("Morir");
            SoundSFxMuerto.InstanceSFxMuerto.Derrota();
            StartCoroutine(TiempoMuerte());

        }
    }


    private IEnumerator TiempoMuerte()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private IEnumerator TiempoDano()
    {
        yield return new WaitForSeconds(1f);
        SoundSFxMuerto.InstanceSFxMuerto.RecibeAtaque();
    }
    private IEnumerator TiempoAtaque()
    {
        yield return new WaitForSeconds(1f);
        SoundSFxMuerto.InstanceSFxMuerto.AtaqueMuerto();
    }

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
                //Debug.Log("Distancia a 5");
            }
            else
            {
                //Debug.Log("Distancia de más de 5");
                navMeshAgent.SetDestination(playerTransform.position);
                animator.SetFloat("speed", navMeshAgent.velocity.sqrMagnitude);
            }
        }
        
    }

    private void Atack()
    {
        navMeshAgent.SetDestination(playerTransform.position);
        if(typeEnemy == 1)
        {
            animator.SetTrigger("AtaqueEnemigo");
            StartCoroutine(TiempoAtaque());
            //SoundSFxMuerto.InstanceSFxMuerto.AtaqueMuerto();
        }
        if (typeEnemy == 2)
        {
            animator.SetTrigger("machetazo");
        }
        
        if (Vector3.Distance(transform.position, playerTransform.position) > 5f)
        {
            enemyState = EnemyState.CHASE;
        }
    }


    /*
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("prota"))
        {
            vidaActual -= ataque;

            if (vidaActual <= 0)
            {
                //caidaScript.lifes -= 1;
                vidaActual = vidaMax;
                //caidaScript.MoverPuntoInicial();
            }

        }
    }

    */

}

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}


