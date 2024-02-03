using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class EnemyAI_Behaviour : MonoBehaviour
{
    public static event Action OnEnemyShoot;

    [Header("Referencias")]
    public NavMeshAgent agent;
    public Transform t_player;
    public LayerMask lm_isGround;
    public LayerMask lm_isPlayer;
    public GameObject go_bullet;
    public Transform t_attackPoint;

    [Header("Atacar")]
    public float f_timeBetweenAttacks;
    bool b_alreadyAttacked;

    [Header("Stats")]
    public float f_shootForce;
    public float f_upwardForce;

    [Header("Estados")]
    public float f_sightRange;
    public float f_attackRange;
    public bool b_playerInSightRange;
    public bool b_playerInAttackRange;

    private Animator animator;
    GameObject go_player;
    GameObject go_currentBullet;

    private void Awake()
    {
        t_player = GameObject.Find("Cylinder").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        go_player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Comprobar el rango de ataque y de vista
        b_playerInSightRange = Physics.CheckSphere(transform.position, f_sightRange, lm_isPlayer);
        b_playerInAttackRange = Physics.CheckSphere(transform.position, f_attackRange, lm_isPlayer);

        if (b_playerInSightRange && !b_playerInAttackRange)
        {
            ChasePlayer();
        }
        if (b_playerInAttackRange && b_playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(t_player.position);
        if (gameObject.name.Contains("mosca"))
        {
            animator.SetTrigger("Fly");
        }
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(t_player);
        if (!b_alreadyAttacked)
        {
            if (animator != null && gameObject.name.Contains("mosca"))
            {
                if (b_playerInAttackRange)
                {
                    Vector3 v3_direction = t_player.position - t_attackPoint.position;
                    OnEnemyShoot?.Invoke();
                    go_currentBullet = Instantiate(go_bullet, t_attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet 
                    Destroy(go_currentBullet, 3f);
                    go_currentBullet.transform.forward = v3_direction.normalized * Time.deltaTime;
                    go_currentBullet.GetComponent<Rigidbody>().useGravity = false;
                    go_currentBullet.GetComponent<Rigidbody>().AddForce(v3_direction.normalized * f_shootForce, ForceMode.Impulse);
                    //go_currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);
                }

            }
            else
            {
                if (b_playerInAttackRange)
                {
                    Vector3 v3_direction = t_player.position - t_attackPoint.position;
                    OnEnemyShoot?.Invoke();
                    go_currentBullet = Instantiate(go_bullet, t_attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet 
                    Destroy(go_currentBullet, 3f);
                    go_currentBullet.transform.forward = v3_direction.normalized * Time.deltaTime;
                    go_currentBullet.GetComponent<Rigidbody>().useGravity = false;
                    go_currentBullet.GetComponent<Rigidbody>().AddForce(v3_direction.normalized * f_shootForce, ForceMode.Impulse);
                    //go_currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);
                }
            }



            b_alreadyAttacked = true;
            Invoke(nameof(ResetAttack), f_timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        b_alreadyAttacked = false;
    }

}
