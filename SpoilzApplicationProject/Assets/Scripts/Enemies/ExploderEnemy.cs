using UnityEngine;
using UnityEngine.AI;

public class ExploderEnemy : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionDamage = 50f;
    public float explodeDistance = 3f;
    public float fuseTime = 0.5f;
    public float moveSpeed = 6f;
    public ParticleSystem explosionParticle;
    public GameObject visualModel;

    private NavMeshAgent agent;
    private Animator animator;
    private Transform player;
    private bool isFusing = false;
    private bool hasExploded = false;
    private float fuseTimer;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = moveSpeed;
        animator.SetBool("shouldExplode", false);
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (!isFusing)
        {
            agent.SetDestination(player.position);
            animator.Play("Explodebt_MoveForward", 0, 0f);

            if (distance <= explodeDistance)
            {
                StartFuse();
            }
        }
        else
        {
            fuseTimer = fuseTimer - Time.deltaTime;

            if (fuseTimer <= 0f)
            {
                Explode();
            }
        }
    }

    private void StartFuse()
    {
        isFusing = true;
        fuseTimer = fuseTime;
        agent.ResetPath();
        animator.SetBool("shouldExplode", true);
    }

    private void Explode()
    {
        if (hasExploded) return;
        hasExploded = true;

        if (visualModel != null)
        {
            visualModel.SetActive(false);
        }

        if (explosionParticle != null)
        {
            explosionParticle.Play();
        }

        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
        bool alreadyDamaged = false;

        foreach (Collider hit in hits)
        {
            PlayerStats stats = hit.GetComponentInParent<PlayerStats>();
            if (stats != null && !alreadyDamaged)
            {
                stats.TakeDamage(explosionDamage);
                alreadyDamaged = true;
            }
        }

        Destroy(gameObject, 1f);
    }
}