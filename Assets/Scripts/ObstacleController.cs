using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // Speed at which the obstacles move upward
    private float _moveSpeed = GameLevel.GameSpeed;

    // Reference to the main camera
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _moveSpeed = GameLevel.GameSpeed;
        // Move the obstacle upward
        transform.Translate(_moveSpeed * Time.deltaTime * Vector2.up);

        // Check if the obstacle has moved out of the screen
        if (transform.position.y > _mainCamera.transform.position.y + _mainCamera.orthographicSize)
        {
            // Destroy the obstacle once it's out of the screen
            Destroy(gameObject);
        }
    }
}