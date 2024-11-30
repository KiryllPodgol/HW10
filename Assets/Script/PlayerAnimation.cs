using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private enum Direction
    {
        StaticN, StaticNW, StaticW, StaticSW, StaticS, StaticSE, StaticE, StaticNE,
        RunN, RunNW, RunW, RunSW, RunS, RunSE, RunE, RunNE
    }

    private int lastDirection;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 _direction)
    {
        Direction direction;

        if (_direction.magnitude < 0.01f)
        {
            direction = (Direction)lastDirection; // Остаемся в последнем направлении
        }
        else
        {
            lastDirection = DirectionToIndex(_direction);
            direction = (Direction)(lastDirection + 8); // Смещение на 8 для бегущих направлений
        }

        anim.SetInteger("Direction", (int)direction);
    }

    private int DirectionToIndex(Vector2 _direction)
    {
        Vector2 norDir = _direction.normalized;

        float step = 360 / 8;
        float offset = step / 2;

        float angle = Vector2.SignedAngle(Vector2.up, norDir);
        angle += offset;

        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
