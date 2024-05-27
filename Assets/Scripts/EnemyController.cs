using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToRevert;
    
    private Rigidbody2D _rigidbody;
    private StateHolder _stateHolder;
    
    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;

    private float currentState;
    private float currentTimeToRevert;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _stateHolder = GetComponent<StateHolder>();
        currentTimeToRevert = 0f;
        currentState = WALK_STATE;
    }

    private void Start()
    {
        _stateHolder.movementState.SetValue(State.Walk);
    }


    private void Update()
    {
        if (currentTimeToRevert >= timeToRevert)
        {
            currentTimeToRevert = 0f;
            currentState = REVERT_STATE;
        }
        
        switch (currentState)
        {
            case IDLE_STATE:
                currentTimeToRevert += Time.deltaTime;
                break;
            case REVERT_STATE:
                transform.Rotate(new Vector2(0, -180));
                currentState = WALK_STATE;
                _stateHolder.movementState.SetValue(State.Walk);
                speed *= -1;
                break;
            case WALK_STATE:
                _rigidbody.velocity = Vector2.right * speed; 
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper"))
        {
            currentState = IDLE_STATE;
            _stateHolder.movementState.SetValue(State.Idle);
        }
    }
}
