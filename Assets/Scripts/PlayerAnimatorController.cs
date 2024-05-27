using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private StateHolder _stateHolder;
    private Animator _animator;
    private String _previousState;
    
    private void Awake()
    {
        _stateHolder = GetComponent<StateHolder>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _stateHolder.movementState.OnChanged += OnMovementStateChanged;
        _stateHolder.shot.OnChanged += OnShot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMovementStateChanged()
    {
        Debug.Log(_stateHolder.movementState.Value);
        var state = _stateHolder.movementState.Value; 
        _animator.SetBool(_previousState, false);
        switch (state)
        {
            case State.Walk:
            {
                _animator.SetBool("Walk", true);
                _previousState = "Walk";
                break;
            }
            case State.Run:
            {
                _animator.SetBool("Run", true);
                _previousState = "Run";
                break;
            }
        }
    }

    private void OnShot()
    {
        if (_stateHolder.shot.Value)
        {
            _animator.SetTrigger("Shot");
        }
    }
}
