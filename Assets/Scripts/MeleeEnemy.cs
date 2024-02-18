using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Attacking")]
    [SerializeField] float timeBetweenAttacks;
    [SerializeField] float chaseSpeed;
    bool alreadyAttacked;
    bool seenPlayer;

    [Header("States")]
    [SerializeField] float sightRange, attackRange;
    bool playerInAttackRange;

    [Header("References")]

    [SerializeField] LayerMask ground, playerMask;
    [SerializeField] Animator animator;
    Transform player;
    NavMeshAgent agent;
    Rigidbody rb;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (!playerInAttackRange) ChasePlayer();
        if (playerInAttackRange) Attack();

        if (!playerInAttackRange && alreadyAttacked) alreadyAttacked = false;

        animator.SetFloat("Speed", agent.velocity.magnitude / chaseSpeed);
    }

    private void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

        if (!alreadyAttacked)
        {
            animator.SetTrigger("Attack");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}