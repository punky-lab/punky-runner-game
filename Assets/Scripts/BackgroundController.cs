using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // Speed at which the background moves upward
    private float _scrollSpeed = GameLevel.GameSpeed;

    // Height of the background sprite
    private float _backgroundHeight;

    // Reference to the camera
    private Camera _mainCamera;


    private void Start()
    {
        // Get the height of the background sprite
        _backgroundHeight = GetComponent<SpriteRenderer>().bounds.size.y;

        // Get the main camera
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _scrollSpeed = GameLevel.GameSpeed;
        // Move the background upward
        transform.Translate(_scrollSpeed * Time.deltaTime * Vector2.up);

        // Check if the background has moved out of the screen
        if (transform.position.y - _backgroundHeight / 2 <
            _mainCamera.transform.position.y + _mainCamera.orthographicSize)
            return;
        
        // The new position is right under the other background
        // Assume that the two background has the same height
        var newPosition = new Vector3(transform.position.x,
            transform.position.y - 2 * _backgroundHeight,
            transform.position.z);
        transform.position = newPosition;
    }
}