using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private PlayerInputController _playerInputController;
    private Animator _animator;
    private String _previousState;
    
    private void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _playerInputController.playerStatus.OnChanged += OnPlayerStatusChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPlayerStatusChanged()
    {
        Debug.Log(_playerInputController.playerStatus.Value);
        var state = _playerInputController.playerStatus.Value;
        _animator.SetBool(_previousState, false);
        switch (state)
        {
            case PlayerInputController.PlayerState.Walk:
            {
                _animator.SetBool("Walk", true);
                _previousState = "Walk";
                break;
            }
            case PlayerInputController.PlayerState.Run:
            {
                _animator.SetBool("Run", true);
                _previousState = "Run";
                break;
            }
            case PlayerInputController.PlayerState.Shot:
            {
                _animator.SetBool("Shot", true);
                _previousState = "Shot";
                break;
            }
        }
    }
}
