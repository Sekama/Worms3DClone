using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("MainMenu")]
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private Button playGameButton;
    [SerializeField] private Button quitGameButton;

    [Header("VictoryScreen")]
    [SerializeField] private GameObject victoryScreenCanvas;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button mainMenuButton;
   
    


    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void Destroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        if(mainMenuCanvas != null) mainMenuCanvas.SetActive(state == GameState.MainMenu);
    
        if (victoryScreenCanvas != null) victoryScreenCanvas.SetActive(state == GameState.Victory);
    }


    public void PlayGamePressed()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void PlayAgainPressed()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void MainMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

     public void QuitGamePressed()
    {
        Application.Quit();
    }
}
