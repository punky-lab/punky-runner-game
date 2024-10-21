using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    // Array of prefabs to spawn
    public GameObject[] obstacles;
    public GameObject[] rewards;
    
    private uint _spawnCounter = 0;
    private int _rewardInterval;
    public int rewardIntervalFrom = 3;
    public int rewardIntervalTo = 6;

    // Spawn interval in seconds
    public float spawnInterval = 1.5f;

    // Reference the main camera
    private Camera _mainCamera;

    public float spawnNarrowX = 0.4f;

    private void Start()
    {
        _mainCamera = Camera.main;
        _rewardInterval = Random.Range(rewardIntervalFrom, rewardIntervalTo);
    }

    private void OnEnable()
    {
        GameLevel.OnGameStart += StartSpawn;
    }

    private void OnDisable()
    {
        GameLevel.OnGameStart -= StartSpawn;
    }

    private void StartSpawn()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    private IEnumerator SpawnObstacleRoutine()
    {
        // print("spawning obstacles");
        while (true)
        {
            if (GameLevel.GamePaused) yield return new WaitForSeconds(1);
            // Wait for the specified spawn interval
            else yield return new WaitForSeconds(spawnInterval / GameLevel.GameSpeedRate);

            // Randomly select a position within the screen width at the bottom
            var xPosition = Random.Range(_mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + spawnNarrowX,
                _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - spawnNarrowX);
            var spawnPosition = new Vector3(xPosition,
                _mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 1, 0);

            if (_spawnCounter >= _rewardInterval)
            {
                _spawnCounter = 0;
                _rewardInterval = Random.Range(rewardIntervalFrom, rewardIntervalTo);
                var index = Random.Range(0, rewards.Length);
                Instantiate(rewards[index], spawnPosition, Quaternion.identity);
            }
            else if (!GameLevel.GamePaused)
            {
                _spawnCounter++;
                var index = Random.Range(0, obstacles.Length);
                Instantiate(obstacles[index], spawnPosition, Quaternion.identity);
            }
        }
    }
}