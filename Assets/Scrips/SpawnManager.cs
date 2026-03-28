using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject rockPrefab;

    public float spawnRate = 2f;      // ทุกกี่วินาที
    public float spawnRange = 5f;     // กระจายซ้ายขวา

    void Start()
    {
        InvokeRepeating("SpawnRock", 1f, spawnRate);
    }

    void SpawnRock()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(
            transform.position.x + randomX,
            transform.position.y,
            transform.position.z + randomZ
        );

        Instantiate(rockPrefab, spawnPos, Quaternion.identity);
    }
}