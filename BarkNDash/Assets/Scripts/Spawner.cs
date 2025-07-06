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
        if (spawnObject == null || spawnObject.Length == 0)
        {
            Debug.LogWarning("Spawner: No objects assigned to spawnObject array!");
            return;
        }

        // Filter out nulls
        var validObjects = System.Array.FindAll(spawnObject, obj => obj != null);
        if (validObjects.Length == 0)
        {
            Debug.LogWarning("Spawner: All objects in spawnObject array are null!");
            return;
        }

        if (gameObject.CompareTag("Reward"))
        {
            GameObject rewardToSpawn = validObjects[Random.Range(0, validObjects.Length)];
            Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-2.0f, 4.0f), 0);
            GameObject spawnedReward = Instantiate(rewardToSpawn, spawnPosition, Quaternion.identity);

            BouncingBall bouncingBall = spawnedReward.GetComponent<BouncingBall>();
            if (bouncingBall != null)
            {
                bouncingBall.speed = objectSpeed;
            }
        }
        else
        {
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
}
