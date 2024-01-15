using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public UnityEngine.UI.Button RetryButton;
    public UnityEngine.UI.Button StartGameButton;
    public UnityEngine.UI.Button ReturnMenuButton;
    public UnityEngine.UI.Button QuitButton;
    
    void Start()
    {
        if (RetryButton) RetryButton.onClick.AddListener(SceneGame);
        if (ReturnMenuButton) ReturnMenuButton.onClick.AddListener(ReturnMenu);
        if (QuitButton) QuitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        if (StartGameButton) StartGameButton.onClick.AddListener(SceneGame);
    }

    void SceneGame()
    {
        SceneManager.LoadScene("Game");
    }

    void ReturnMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
