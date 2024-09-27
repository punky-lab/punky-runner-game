using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    // left: -1
    // right: 1
    private int _direction;

    private void Start()
    {
        _direction = 0;
    }

    private void Update()
    {
        var direction = new Vector3(_direction, 0, 0);
        direction.Normalize();
        direction *= speed * Time.deltaTime;
        transform.Translate(direction);
    }

    private void OnEnable()
    {
        SwipeDetector.OnSwipeLeft += HandleSwipeLeft;
        SwipeDetector.OnSwipeRight += HandleSwipeRight;
    }

    private void OnDisable()
    {
        SwipeDetector.OnSwipeLeft -= HandleSwipeLeft;
        SwipeDetector.OnSwipeRight -= HandleSwipeRight;
    }

    private void HandleSwipeLeft()
    {
        // print("Swiped Left!");
        _direction = -1;
    }

    private void HandleSwipeRight()
    {
        // print("Swiped Right!");
        _direction = 1;
    }
}