using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    // Game speed increase per second
    public float gameSpeedIncrease = 0.3f;
    
    public static float GameSpeed = 3.0f;

    private void Update()
    {
        GameSpeed += gameSpeedIncrease * Time.deltaTime;
    }
}
