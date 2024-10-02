using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Array of obstacle prefabs to spawn
    public GameObject[] obstacles;

    // Spawn interval in seconds
    public float spawnInterval = 1.5f;

    // Reference the main camera
    private Camera _mainCamera;

    public float spawnNarrowX = 0.4f;

    private void Start()
    {
        _mainCamera = Camera.main;
        // Start the spawning coroutine
        StartCoroutine(SpawnObstacleRoutine());
    }

    private IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            // Wait for the specified spawn interval
            yield return new WaitForSeconds(spawnInterval / GameLevel.GameSpeedRate);

            // Randomly select an obstacle prefab
            var index = Random.Range(0, obstacles.Length);

            // Randomly select a position within the screen width at the bottom
            var xPosition = Random.Range(_mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + spawnNarrowX,
                _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - spawnNarrowX);
            var spawnPosition = new Vector3(xPosition,
                _mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 1, 0);

            // Instantiate the selected obstacle at the spawn position
            Instantiate(obstacles[index], spawnPosition, Quaternion.identity);
        }
    }
}