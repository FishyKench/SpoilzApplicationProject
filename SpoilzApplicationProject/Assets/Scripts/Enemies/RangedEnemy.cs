using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.iOS;

public class RangedEnemy : MonoBehaviour
{
    public Transform player;
    public Transform firePoint;
    public Animator animator;
    public float attackRange = 10f;
    public float fireRate = 1f;
    public float damage = 10f;

    private NavMeshAgent agent;
    private float fireTimer;
    private string currentState = "Chase";

    private PlayerStats playerStats;

    private void Awake()
    {
        playerStats = FindAnyObjectByType<PlayerStats>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator.Play("TRT_MoveForward");
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (currentState == "Chase")
        {
            agent.SetDestination(player.position);

            if (distance <= attackRange)
            {
                currentState = "Attack";
                agent.ResetPath();
                animator.Play("TRT_Shoot");
            }
        }
        else if (currentState == "Attack")
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0f;
            transform.rotation = Quaternion.LookRotation(direction);

            fireTimer = fireTimer - Time.deltaTime;

            if (fireTimer <= 0f)
            {
                Shoot();
                fireTimer = fireRate;
            }

            if (distance > attackRange)
            {
                currentState = "Chase";
                animator.Play("TRT_MoveForward");
            }
        }
    }

    private void Shoot()
    {
        animator.Play("TRT_Shoot", 0, 0f);

        Vector3 direction = player.position - firePoint.position;
        direction = direction.normalized;

        if (Physics.Raycast(firePoint.position, direction, out RaycastHit hit, attackRange))
        {
            if(playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }


            Debug.Log("Hit: " + hit.collider.name);
            Debug.DrawLine(firePoint.position, hit.point, Color.red, 0.5f);
        }
    }
}