using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class GameLevelController : MonoBehaviour
{
    // public Button gameStartButton;
    // public Button gameRestartButton;
    // public Button gameQuitButton;
    
    [DllImport("__Internal")]
    private static extern void RedirectToPunkyApp();
    
    // private void Start()
    // {
    //     gameStartButton.onClick.AddListener(StartGame);
    //     gameRestartButton.onClick.AddListener(RestartGame);
    //     gameQuitButton.onClick.AddListener(QuitGame);
    // }
    
    public static void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void QuitGame()
    {
        Application.Quit();
        // Application.ExternalEval("window.location.href='http://www.example.com';");
        RedirectToPunkyApp();
    }
}
