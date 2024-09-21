using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    // left: -1
    // right: 1
    public int Direction { get; private set; }

    private void Start()
    {
        Direction = 0;
    }

    private void Update()
    {
        var direction = new Vector3(Direction, 0, 0);
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
        print("Swiped Left!");
        Direction = -1;
    }

    private void HandleSwipeRight()
    {
        print("Swiped Right!");
        Direction = 1;
    }
}