using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private StateHolder _stateHolder;
    
    private Text _clipAmmoText;
    private Text _ammoText;

    private void Awake()
    {
        _clipAmmoText = transform.Find("ClipAmmoText").gameObject.GetComponent<Text>();
        _ammoText = transform.Find("AmmoText").gameObject.GetComponent<Text>();
        
        _clipAmmoText.text = "В обойме: " + _stateHolder.clipAmmo.Value + "/" + StateHolder.CLIP_CAPACITY;
        _ammoText.text = "Патроны: " + _stateHolder.ammoCount.Value;
    }

    void Start()
    {
        _stateHolder.clipAmmo.OnChanged += () =>
        {
            _clipAmmoText.text = "В обойме: " + _stateHolder.clipAmmo.Value + "/" + StateHolder.CLIP_CAPACITY;
        };
        
        _stateHolder.ammoCount.OnChanged += () =>
        {
            _ammoText.text = "Патроны: " + _stateHolder.ammoCount.Value;
        };
    }

   
    void Update()
    {
        
    }
}
