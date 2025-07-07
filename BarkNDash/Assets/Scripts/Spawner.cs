using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnObject;

    private float timeUntilObstacleSpawn;

    public float spawnTime = 5f;
    public float objectSpeed = 5f;

    private void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= spawnTime && !GameController.Instance.IsGameOver())
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void Spawn()
    {
        var validObjects = System.Array.FindAll(spawnObject, obj => obj != null);
        GameObject obstacleToSpawn = validObjects[Random.Range(0, validObjects.Length)];
        Vector3 spawnPosition = transform.position;
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);

        ObstacleMover mover = spawnedObstacle.GetComponent<ObstacleMover>();
        if (mover != null)
        {
            mover.speed = objectSpeed;
        }
    }
}
