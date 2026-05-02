using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{
    public Transform cameraTransform;
    public float range = 50f;
    public float damage = 25f;
    public float fireRate = 0.5f;

    private float fireTimer;

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
    }

    private void Shoot()
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, range))
        {
            Debug.Log("Shot: " + hit.collider.name);

            EnemyStats enemy = hit.collider.GetComponent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}