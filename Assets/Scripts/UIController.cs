using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private StateHolder _stateHolder;
    private Text _ammoText;

    private void Awake()
    {
        _ammoText = transform.Find("AmmoText").gameObject.GetComponent<Text>();
        _ammoText.text = "Патроны: " + _stateHolder.ammoCount.Value + "/" + StateHolder.MAX_AMMO;
    }

    void Start()
    {
        _stateHolder.ammoCount.OnChanged += () =>
        {
            _ammoText.text = "Патроны: " + _stateHolder.ammoCount.Value + "/" + StateHolder.MAX_AMMO;
        };
    }

   
    void Update()
    {
        
    }
}
