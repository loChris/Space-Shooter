﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    public bool isCoopMode = false;

    void Update()
    {
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
}
