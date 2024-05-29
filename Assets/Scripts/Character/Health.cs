using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    
    private StateHolder _stateHolder;

    private void Awake()
    {
        _stateHolder = GetComponent<StateHolder>();
        _stateHolder.health.SetValue(maxHealth);
    }

    public void Damage(float damage)
    {
        _stateHolder.health.SetValue(_stateHolder.health.Value - damage);
    }

    public void Heal(float heal)
    {
        _stateHolder.health.SetValue(Math.Max(_stateHolder.health.Value + heal, maxHealth));
    }
}
