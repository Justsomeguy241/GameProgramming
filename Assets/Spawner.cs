using System.Collections;
using System.Reflection;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyPreFab;

    [Header("Number of enemies")]
    [SerializeField] int minEnemyPerBatch = 3;
    [SerializeField] int MaxEnemyPerBatch = 6;

    [Header("Spawn Interval")]
    [SerializeField] float minSpawnInterval = 3f;
    [SerializeField] float MaxSpawnInterval = 5f;

    [Header("Spawn Radius")]
    [SerializeField] float MinSpawnRadius = 6f;
    [SerializeField] float MaxSpawnRadius = 10f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private  IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float interval = Random.Range(minSpawnInterval, MaxSpawnInterval);
            yield return new WaitForSeconds(interval);

            int enemiesBatchSize = Random.Range(minEnemyPerBatch, MaxEnemyPerBatch);
            for (int i = 0;  i < enemiesBatchSize; i++)
            {
                Vector2 SpawnOffset = Random.insideUnitCircle * Random.Range(MinSpawnRadius, MaxSpawnRadius);
                Vector2 SpawnPosition = (Vector2)gameObject.transform.position + SpawnOffset;

                Instantiate(EnemyPreFab, SpawnPosition, Quaternion.identity);
            }
        }
    }

}
