using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float chaseRange = 8f;
    public float attackRange = 1.5f;

    [Header("Components")]
    public Transform player;
    public Animator animator;

    private float distanceToPlayer;

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        HandleMovement();
        HandleAnimations();
    }

    // Enemy movement logic
    void HandleMovement()
    {
        if (distanceToPlayer <= attackRange)
        {
            AttackPlayer();
            return;
        }

        if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    // Patrol behavior
    void Patrol()
    {
        animator.SetBool("IsMoving", false);
    }

    // Chase behavior
    void ChasePlayer()
    {
        animator.SetBool("IsMoving", true);

        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        transform.LookAt(player);
    }

    // Attack behavior
    void AttackPlayer()
    {
        animator.SetTrigger("Attack");
    }

    // Animation control
    void HandleAnimations()
    {
        animator.SetFloat("Distance", distanceToPlayer);
    }
}
