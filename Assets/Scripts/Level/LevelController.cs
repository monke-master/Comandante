using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityObservables;

public class LevelController : MonoBehaviour
{
    
    public static Observable<int> playerPoints = new Observable<int>() { Value = 0 };
    private static LevelController _instance;

    private void Awake()
    {
        _instance = this;
    }

    private IEnumerator OnVictory()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Scenes/VictoryScene");
    }
    
    private IEnumerator DefeatDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Scenes/DefeatScene");
    }
    
    public static void OnLevelComplete()
    {
        _instance.StartCoroutine("OnVictory");
    }
    
    public static void OnDefeat()
    {
        _instance.StartCoroutine("DefeatDelay");
    }

    public static void AddPoints(int points)
    {
        playerPoints.SetValue(playerPoints.Value + points);
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public static void ToMenu()
    {
        SceneManager.LoadScene("Scenes/MenuScene");
    }

}
