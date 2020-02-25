using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;

    void Update()
    {
        if (_isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(1); //main game scene

            if (Input.GetKeyDown(KeyCode.Q))
                SceneManager.LoadScene(0);
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
