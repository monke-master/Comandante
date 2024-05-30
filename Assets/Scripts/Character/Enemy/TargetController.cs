using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetController : MonoBehaviour
{

    [SerializeField] private float _targetDistance = 10f;
    [SerializeField] private LayerMask _targetLayerMask;
    
    
    private EnemyController _enemyController;
    private StateHolder _stateHolder;

    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
        _stateHolder = GetComponent<StateHolder>();
    }


    void Update()                                                                                                      
    {
        var direction = Vector2.right * _stateHolder.direction;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _targetDistance, _targetLayerMask);
        Debug.DrawRay(transform.position, direction * _targetDistance);
        if (hit.collider != null)
        {
            Debug.Log("ГООООООООЛ");
            _enemyController.Follow(hit.transform);
        }
    }
}
