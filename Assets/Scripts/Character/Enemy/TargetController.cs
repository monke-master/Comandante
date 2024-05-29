using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetController : MonoBehaviour
{

    [SerializeField] private float _targetDistance = 10f;
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _targetDistance);
        Debug.DrawRay(transform.position, direction * _targetDistance);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                Debug.Log("ГООООООООЛ");
                _enemyController.Follow(hit.transform);
            }
        }
    }
}
