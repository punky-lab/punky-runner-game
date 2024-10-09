using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameLevel : MonoBehaviour
{
    public static UnityAction OnGameStart;
    public static UnityAction OnGameOver;

    // Game speed increase per second
    public float gameSpeedIncrease = 0.3f;

    public GameObject gameOverUI;
    public GameObject gameStartUI;

    private static GameLevel _instance;

    public static float GameSpeed = 3.0f;

    private static readonly float InitialGameSpeed = GameSpeed;
    public static float GameSpeedRate => GameSpeed / InitialGameSpeed;
    public static bool GamePaused { get; private set; }

    private void Start()
    {
        GameSpeed = 0;
        gameOverUI.SetActive(false);
        gameStartUI.SetActive(true);
        _instance = this;
        GamePaused = true;
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
        _instance.gameOverUI.SetActive(true);
        OnGameOver?.Invoke();
    }

    public static void GameStart()
    {
        GameSpeed = InitialGameSpeed;
        GamePaused = false;
        _instance.gameStartUI.SetActive(false);
        OnGameStart?.Invoke();
    }
}