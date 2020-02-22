﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //create a handle to Text
    [SerializeField] private Text _scoreText;
    [SerializeField] private Image _livesImg;
    [SerializeField] private Sprite[] _livesSprites;
    [SerializeField] private Text _gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        //assign text component to handle to use it
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);

    }

    public void UpdateScoreOnScreen(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _livesSprites[currentLives];
        if (currentLives <= 0)
        {
            _gameOverText.gameObject.SetActive(true);
        }
    }
}
