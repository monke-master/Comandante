using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Jobs;
using UnityEngine;
using UnityObservables;


public class PlayerInputController : MonoBehaviour
{
    [System.Serializable]
    public class ObservableStatus: Observable<PlayerState> {}

    public ObservableStatus playerStatus = new ObservableStatus() {  };

    private PlayerMovementController _playerMovementController;

    private void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
    }

    void Start()
    {
        playerStatus.SetValue(PlayerState.Idle);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerStatus.SetValue(PlayerState.Shot);
        }

        var boost = 1f;
        var direction = Input.GetAxis("Horizontal");
        var axisDirection = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump"))
        {
            _playerMovementController.JumpIfCan();
        }

        if (axisDirection == 0)
        {
            playerStatus.SetValue(PlayerState.Idle);
            return;
        }

        playerStatus.SetValue(PlayerState.Walk);

        bool isRun = false;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRun = true;
            playerStatus.SetValue(PlayerState.Run);
        }

        if (Mathf.Abs(direction) > 0.01f)
        {
            _playerMovementController.HorizontalMovement(direction, axisDirection, isRun);
        }

        
    }

    public enum PlayerState
    {
        Idle = 0, 
        Walk = 1, 
        Run = 2,
        Shot = 3
    }
    
    
}
