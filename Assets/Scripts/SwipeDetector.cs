using UnityEngine;
using UnityEngine.Events;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 _fingerDownPosition;
    private Vector2 _fingerUpPosition;

    [SerializeField] private bool detectSwipeOnlyAfterRelease = false;
    [SerializeField] private float minDistanceForSwipe = 20f;
    
    public static event UnityAction OnSwipeLeft;   // Event for left swipe
    public static event UnityAction OnSwipeRight;  // Event for right swipe

    private void Update()
    {
        foreach (var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                _fingerUpPosition = touch.position;
                _fingerDownPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                _fingerDownPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (!SwipeDistanceCheckMet()) return;

        if (IsVerticalSwipe())
        {
            // var direction = _fingerDownPosition.y - _fingerUpPosition.y > 0 ? "Up" : "Down";
            // print("Vertical Swipe Detected! Direction: " + direction);
            // add vertical swipe event trigger here
        }
        else
        {
            var direction = _fingerDownPosition.x - _fingerUpPosition.x > 0 ? "Right" : "Left";
            // print("Horizontal Swipe Detected! Direction: " + direction);
            
            switch (direction)
            {
                case "Right":
                    OnSwipeRight?.Invoke();
                    break;
                case "Left":
                    OnSwipeLeft?.Invoke();
                    break;
                default:
                    // never
                    return;
            }
        }

        _fingerUpPosition = _fingerDownPosition;
    }

    private bool SwipeDistanceCheckMet()
    {
        return VerticalMovementDistance() > minDistanceForSwipe ||
               HorizontalMovementDistance() > minDistanceForSwipe;
    }

    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    private float VerticalMovementDistance()
    {
        return Mathf.Abs(_fingerDownPosition.y - _fingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(_fingerDownPosition.x - _fingerUpPosition.x);
    }
}