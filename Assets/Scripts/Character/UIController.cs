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
    private Text _healthText;
    private Text _scoreText;

    private void Awake()
    {
        _clipAmmoText = transform.Find("ClipAmmoText").gameObject.GetComponent<Text>();
        _ammoText = transform.Find("AmmoText").gameObject.GetComponent<Text>();
        _healthText = transform.Find("HealthText").gameObject.GetComponent<Text>();
        _scoreText = transform.Find("PointsText").gameObject.GetComponent<Text>();
        
        _clipAmmoText.text = "В обойме: " + _stateHolder.clipAmmo.Value + "/" + StateHolder.CLIP_CAPACITY;
        _ammoText.text = "Патроны: " + _stateHolder.ammoCount.Value;
        _healthText.text = "Здоровье: " + _stateHolder.health.Value + "/" + _stateHolder.MAX_HEALTH;
        _scoreText.text = "Очки: " + LevelController.playerPoints.Value;
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
        
        _stateHolder.health.OnChanged += () =>
        {
            _healthText.text = "Здоровье: " + Math.Max(_stateHolder.health.Value, 0) + "/" + _stateHolder.MAX_HEALTH;
        };

        LevelController.playerPoints.OnChanged += () =>
        {
            _scoreText.text = "Очки: " + LevelController.playerPoints.Value;
        };
    }

}
