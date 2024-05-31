using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryUIController : MonoBehaviour
{
    private void Awake()
    {
        var scoreText = transform.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Очков набрано: " + LevelController.playerPoints.Value;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Scenes/MenuScene");
    }

}
