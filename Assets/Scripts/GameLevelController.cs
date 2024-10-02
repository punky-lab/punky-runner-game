using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLevelController : MonoBehaviour
{
    public Button gameStartButton;
    public Button gameRestartButton;
    
    private void Start()
    {
        gameRestartButton.onClick.AddListener(RestartGame);
    }

    private static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
