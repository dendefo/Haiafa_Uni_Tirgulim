using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    [SerializeField] float spawnInterval = 2.0f;
    [SerializeField] Obstacle obstaclePrefab;
    [SerializeField] List<Obstacle> obstaclePool;
    [SerializeField] float minY = 1f;
    [SerializeField] float maxY = 1f;
    [SerializeField] int poolSize = 5;
    private float timeSinceLastSpawn = 0f;

    private void Awake()
    {
        obstaclePool = new List<Obstacle>();
        for (int i = 0; i < poolSize; i++)
        {
            AddToPool();
        }
    }
    void Update()
    {

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObstacle();
            timeSinceLastSpawn = 0f;
        }
    }
    private void AddToPool()
    {
        Obstacle newObstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        newObstacle.gameObject.SetActive(false);
        obstaclePool.Add(newObstacle);
    }

    void SpawnObstacle()
    {
        var disabledObstacle = obstaclePool.FirstOrDefault(obstacle => !obstacle.gameObject.activeSelf);

        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(minY, maxY), 0);
        if (disabledObstacle != null)
        {
            disabledObstacle.transform.position = spawnPosition;
            disabledObstacle.gameObject.SetActive(true);
        }
        else
        {
            AddToPool();
            SpawnObstacle();
        }
    }
}
