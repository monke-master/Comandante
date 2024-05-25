using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public float runBoost = 2f;
    [SerializeField] private AnimationCurve speedCurve;
    
    private Rigidbody2D _rigidbody;
    private int currentDirection = 1;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void HorizontalMovement(float direction, float axisDirection, float boost)
    {
        if (axisDirection != 0 && axisDirection*currentDirection < 0)
        {
            transform.Rotate(new Vector2(0, -180));
            currentDirection *= -1;
        }
        _rigidbody.velocity = new Vector2(speedCurve.Evaluate(direction)*speed*boost, _rigidbody.velocity.y);
    }
}
