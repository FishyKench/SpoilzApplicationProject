using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{
    public Transform cameraTransform;
    public float range = 50f;
    public float damage = 25f;
    public float fireRate = 0.5f;
    public LineRenderer bulletLine;
    public float lineDisplayTime = 0.1f;

    public AudioSource audioSource;

    public AudioClip gunSound;

    private float fireTimer;
    private float lineTimer;

    public void OnAttack(InputValue value)
    {
        if (Time.timeScale == 0f) return;
        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
    }

    private void Update()
    {
        if (fireTimer > 0f)
        {
            fireTimer = fireTimer - Time.deltaTime;
        }

        if (lineTimer > 0f)
        {
            lineTimer = lineTimer - Time.deltaTime;
            if (lineTimer <= 0f)
            {
                bulletLine.enabled = false;
            }
        }
    }

    private void Shoot()
    {
        audioSource.PlayOneShot(gunSound);
        Vector3 startPoint = cameraTransform.position 
            + cameraTransform.forward * 0.5f 
            + cameraTransform.right * 0.3f 
            + cameraTransform.up * -0.2f;

        Vector3 endPoint = cameraTransform.position + cameraTransform.forward * range;

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, range))
        {
            EnemyStats enemy = hit.collider.GetComponent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            endPoint = hit.point;
        }

        Vector3 shootDirection = (endPoint - startPoint).normalized;
        bulletLine.SetPosition(0, startPoint);
        bulletLine.SetPosition(1, endPoint);
        bulletLine.enabled = true;
        lineTimer = lineDisplayTime;
    }
}