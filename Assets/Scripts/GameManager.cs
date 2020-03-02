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
    private Animator _pauseAnimator;
    
    private void Start()
    {
        _pauseAnimator = GameObject.Find("Pause_Menu_panel").GetComponent<Animator>();
        _pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        HidePauseMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            switch (Time.timeScale)
            {
                case 1:
                    ShowPauseMenu();
                    break;
                case 0:
                    HidePauseMenu();
                    break;
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
        _pauseAnimator.SetBool("isPaused", true);
        Time.timeScale = 0;
    }
}
