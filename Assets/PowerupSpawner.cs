using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject[] powerupPrefabs;       // Lista de power-ups possíveis
    public float spawnInterval = 8f;          // Tempo entre cada spawn
    public float spawnXRange = 6f;            // Limite horizontal
    public float spawnYRange = 3.5f;          // Limite vertical

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomPowerup), 3f, spawnInterval);
    }

    void SpawnRandomPowerup()
    {
        if (powerupPrefabs.Length == 0) return;

        int index = Random.Range(0, powerupPrefabs.Length); // Escolhe um power-up aleatório
        Vector2 randomPosition = new Vector2(
            Random.Range(-spawnXRange, spawnXRange),
            Random.Range(-spawnYRange, spawnYRange)
        );

        Instantiate(powerupPrefabs[index], randomPosition, Quaternion.identity);
    }
}