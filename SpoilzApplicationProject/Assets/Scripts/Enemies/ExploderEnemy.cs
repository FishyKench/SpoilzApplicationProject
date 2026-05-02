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
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (!isFusing)
        {
            agent.SetDestination(player.position);

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

        foreach (Collider hit in hits)
        {
            PlayerStats stats = hit.GetComponent<PlayerStats>();
            if (stats != null)
            {
                stats.TakeDamage(explosionDamage);
            }
        }

        Destroy(gameObject, 1f);
    }
}