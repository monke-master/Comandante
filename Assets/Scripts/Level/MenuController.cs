using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject settingsCanvas;
    
    public void ToSettings()
    {
        menuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }
    
    public void ToMenu()
    {
        settingsCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public void ToLevel()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
