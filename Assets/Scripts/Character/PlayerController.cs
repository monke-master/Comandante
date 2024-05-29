using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private StateHolder _stateHolder;

    private void Awake()
    {
        _stateHolder = GetComponent<StateHolder>();
    }


    void Start()
    {
        _stateHolder.health.OnChangedValues += Health_OnChangedValues;
    }

    

    void Update()
    {
        
    }


    private void Health_OnChangedValues(float _, float health)
    {
        if (health == 0)
        {
            _stateHolder.movementState.SetValue(State.Dead);
        }
    }

}
