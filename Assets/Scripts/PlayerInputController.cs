using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Jobs;
using UnityEngine;
using UnityObservables;


public class PlayerInputController : MonoBehaviour
{
    private CharacterMovementController _movementController;
    private StateHolder _stateHolder;
    private StateHolder.ObservableState _movementState;

    private void Awake()
    {
        _movementController = GetComponent<CharacterMovementController>();
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
            _movementController.JumpIfCan();
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
                _movementController.HorizontalMovement(direction, axisDirection, isRun);
            }
        }


        

        if (Input.GetMouseButton(1))
        {
            _stateHolder.movementState.SetValue(State.Aim);
        }

        if (Input.GetMouseButton(0))
        {

            _stateHolder.shot.SetValue(true);
            _stateHolder.shot.SetValue(false);

        }

    }


    
}
