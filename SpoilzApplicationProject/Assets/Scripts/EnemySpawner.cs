using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject rangedEnemyPrefab;
    public GameObject exploderEnemyPrefab;
    public float spawnRadius = 15f;

    private float spawnTimer;

    private void Update()
    {
        spawnTimer = spawnTimer - Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = Random.Range(1f, 2f);
        }
    }

    private void SpawnEnemy()
    {
        Vector2 random = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = transform.position + new Vector3(random.x, 0f, random.y);

        int pick = Random.Range(0, 2);

        if (pick == 0)
        {
            Instantiate(rangedEnemyPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(exploderEnemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}