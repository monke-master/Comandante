using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToRevert;
    [SerializeField] private float stopFollowingDistance = 100f;
    [SerializeField] private float distanceToShot = 20f;
    
    
    private Rigidbody2D _rigidbody;
    private StateHolder _stateHolder;
    
    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;

    private float currentState;
    private float currentTimeToRevert;
    private float _currentSpeed;

    private Transform _target;
    

    private void Awake()
    {
        _currentSpeed = speed;
        _rigidbody = GetComponent<Rigidbody2D>();
        _stateHolder = GetComponent<StateHolder>();
        currentTimeToRevert = 0f;
        currentState = WALK_STATE;

        _stateHolder.health.OnChangedValues += (_, health) =>
        {
            if (health <= 0)
            {
                _stateHolder.movementState.SetValue(State.Dead);
                enabled = false;
                _rigidbody.simulated = false;        
            }
        };
    }

    private void Start()
    {
        _stateHolder.movementState.SetValue(State.Walk);
    }


    private void Update()
    {
        if (_target == null)
        {
            Patrolling();
        }
        else
        {
            Following();
        }
    }

    private void Rotate()
    {
        transform.Rotate(new Vector2(0, -180));
        _stateHolder.direction *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper"))
        {
            currentState = IDLE_STATE;
            _stateHolder.movementState.SetValue(State.Idle);
        }
    }

    public void Follow(Transform transform)
    {
        _target = transform;
    }

    private void Patrolling()
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
                currentState = WALK_STATE;
                _stateHolder.movementState.SetValue(State.Walk);
                Rotate();
                break;
            case WALK_STATE:
                _rigidbody.velocity = Vector2.right * (speed * _stateHolder.direction); 
                break;
        }
    }

    private void Following()
    {
        var distance = Vector2.Distance(transform.position, _target.position);
        if (distance > stopFollowingDistance)
        {
            _target = null;
            return;
        }

        var followingDirection = _target.position.x - transform.position.x;
        if (_stateHolder.direction * followingDirection < 0)
        {
            Rotate();
        }

        if (distance <= distanceToShot)
        {
            _currentSpeed = 0;
            _stateHolder.movementState.SetValue(State.Aim);
            _stateHolder.movementState.SetValue(State.Shot);
        }
        else
        {
            _stateHolder.movementState.SetValue(State.Run);
            _currentSpeed = speed * 2;
            _rigidbody.velocity = Vector2.right * (speed * _stateHolder.direction); 
        }
        
    }
}