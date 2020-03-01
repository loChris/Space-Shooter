using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    public bool isCoopMode = false;
    [SerializeField] private GameObject _pauseMenu;
    
    private void Start()
    {
        HidePauseMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                ShowPauseMenu();
            } else if (Time.timeScale == 0)
            {
                Debug.Log("hmph");
                HidePauseMenu();
            }
        }
        
        if (_isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(1); //main game scene
            else if (Input.GetKeyDown(KeyCode.Q))
                SceneManager.LoadScene(0);
            else if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    void HidePauseMenu()
    {
        _pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void ShowPauseMenu()
    {
        _pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
