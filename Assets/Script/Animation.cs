using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private const int DirectionCount = 8; // Total number of directions
    private const float AngleStep = 360f / DirectionCount; // Degrees per direction slice
    private const float AngleOffset = AngleStep / 2; // Offset for angle calculation

    private enum AnimationDirection
    {
        StaticN, StaticNW, StaticW, StaticSW,
        StaticS, StaticSE, StaticE, StaticNE,
        RunN, RunNW, RunW, RunSW,
        RunS, RunSE, RunE, RunNE
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
      
    }

    public void SetDirection(Vector2 direction)
    {
        if (direction.magnitude < 0.01f) // Character is static
        {
            PlayAnimation(AnimationDirection.StaticN); // Default static animation
        }
        else
        {
            int directionIndex = GetDirectionIndex(direction);
            PlayAnimation((AnimationDirection)(directionIndex + (int)AnimationDirection.RunN));
        }
    }

    private void PlayAnimation(AnimationDirection direction)
    {
        animator.Play(direction.ToString());
    }

    private int GetDirectionIndex(Vector2 direction)
    {
        Vector2 normalizedDirection = direction.normalized;
        float angle = Vector2.SignedAngle(Vector2.up, normalizedDirection) + AngleOffset;

        if (angle < 0)
        {
            angle += 360;
        }

        return Mathf.FloorToInt(angle / AngleStep) % DirectionCount; // Ensure index wraps around
    }
}
