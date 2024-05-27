using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Jobs;
using UnityEngine;
using UnityObservables;


public class PlayerInputController : MonoBehaviour
{
    private PlayerMovementController _playerMovementController;
    private StateHolder _stateHolder;
    private StateHolder.ObservableState _movementState;

    private void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
        _stateHolder = GetComponent<StateHolder>();
        _movementState = _stateHolder.movementState;
    }

    void Start()
    {
        _movementState.SetValue(State.Idle);
    }

    private void Update()
    {
        var boost = 1f;
        var direction = Input.GetAxis("Horizontal");
        var axisDirection = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump"))
        {
            _playerMovementController.JumpIfCan();
        }

        if (axisDirection == 0)
        { 
            _movementState.SetValue(State.Idle);
        } 
        else
        {
            _movementState.SetValue(State.Walk);

            bool isRun = false;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRun = true;
                _movementState.SetValue(State.Run);
            }

            if (Mathf.Abs(direction) > 0.01f)
            {
                _playerMovementController.HorizontalMovement(direction, axisDirection, isRun);
            }
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            _stateHolder.shot.SetValue(true);
            _stateHolder.shot.SetValue(false);
        }

    }
    
}
