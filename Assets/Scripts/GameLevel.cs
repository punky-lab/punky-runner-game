using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    // Game speed increase per second
    public float gameSpeedIncrease = 0.3f;

    public GameObject gameOverText;

    public static GameLevel Instance;

    public static float GameSpeed = 3.0f;

    private static float _initialGameSpeed = GameSpeed;
    public static float GameSpeedRate => GameSpeed / _initialGameSpeed;
    public static bool GamePaused { get; private set; }

    private void Start()
    {
        GameSpeed = _initialGameSpeed;
        gameOverText.SetActive(false);
        Instance = this;
        GamePaused = false;
    }

    private void Update()
    {
        if (GamePaused) return;
        GameSpeed += gameSpeedIncrease * Time.deltaTime;
    }

    public static void GameOver()
    {
        GameSpeed = 0;
        GamePaused = true;
        Instance.gameOverText.SetActive(true);
    }
}