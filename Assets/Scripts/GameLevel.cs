using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    // Game speed increase per second
    public float gameSpeedIncrease = 0.3f;

    public GameObject gameOverText;

    private static GameLevel _instance;

    public static float GameSpeed = 3.0f;

    private static readonly float InitialGameSpeed = GameSpeed;
    public static float GameSpeedRate => GameSpeed / InitialGameSpeed;
    public static bool GamePaused { get; private set; }

    private void Start()
    {
        GameSpeed = InitialGameSpeed;
        gameOverText.SetActive(false);
        _instance = this;
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
        _instance.gameOverText.SetActive(true);
    }
}