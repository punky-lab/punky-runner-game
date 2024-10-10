using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RewardEffect : MonoBehaviour
{
    public static UnityAction OnGetReward;
    // Rotation speed in degrees per second.
    public float rotationSpeed = 360f; 

    private void Update()
    {
        // Calculate the rotation amount based on time and speed.
        var rotationAmount = rotationSpeed * Time.deltaTime;
        
        // Apply rotation around the Y-axis. You may change Vector3.up to Vector3.right or Vector3.forward for different axes.
        transform.Rotate(Vector3.up, rotationAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.CompareTag("Player"))
        {
            OnGetReward?.Invoke();
            Destroy(gameObject);
        }
    }
}
