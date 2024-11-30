using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private enum Direction
    {
        StaticN, StaticNW, StaticW, StaticSW, StaticS, StaticSE, StaticE, StaticNE,
        RunN, RunNW, RunW, RunSW, RunS, RunSE, RunE, RunNE
    }

    int lastDirection;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        float result1 = Vector2.SignedAngle(Vector2.up, Vector2.right);
        Debug.Log("R1 " + result1);

        float result2 = Vector2.SignedAngle(Vector2.up, Vector2.left);
        Debug.Log("R2 " + result2);

        float result3 = Vector2.SignedAngle(Vector2.up, Vector2.down);
        Debug.Log("R3 " + result3);
    }

    public void SetDirection(Vector2 _direction)
    {
        Direction direction;

        if (_direction.magnitude < 0.01)
        {
            direction = (Direction)lastDirection;
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
