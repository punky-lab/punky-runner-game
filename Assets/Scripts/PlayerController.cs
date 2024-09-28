using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.5f;
    public float moveBoundary = 1.6f;

    // left: -1
    // right: 1
    private int _direction;
    
    private Animator _animator;

    private void Start()
    {
        _direction = 0;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameLevel.GamePaused) return;
        var direction = new Vector3(_direction, 0, 0);
        direction.Normalize();
        direction *= speed * Time.deltaTime;
        var position = transform.position + direction;
        if (Mathf.Abs(position.x) > moveBoundary) return;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleGameOver();
    }

    private void HandleGameOver()
    {
        print("end game");
        GameLevel.GameOver();
    }

    private void HandleSwipeLeft()
    {
        // print("Swiped Left!");
        _direction = -1;
        _animator.SetInteger("Direction", -1);
    }

    private void HandleSwipeRight()
    {
        // print("Swiped Right!");
        _direction = 1;
        _animator.SetInteger("Direction", 1);
    }
}