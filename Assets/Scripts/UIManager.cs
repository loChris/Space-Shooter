using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int _newHighScore;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highScoreText;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private GameObject _deathScreenText;
    [SerializeField] private Sprite[] _livesSprites;
    [SerializeField] private Image _livesImg;
    private GameManager _gameManager;
    [SerializeField] private GameObject _pauseMenu;

    void Start()
    {
        GetGameObjects();
        UIText();
    }

    void UIText()
    {
        _scoreText.text = "Score: " + 0;
        _highScoreText.text = "High-Score: " + PlayerPrefs.GetInt("HighScore", 0);
        _gameOverText.gameObject.SetActive(false);
        _deathScreenText.gameObject.SetActive(false);
    }

    void GetGameObjects()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("game manager is null");
        }
    }

    public void UpdateScoreOnScreen(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }
    
    public void UpdateHighScore(int playerScore)
    {
        if (playerScore > _newHighScore)
        {
            _newHighScore = playerScore;
            PlayerPrefs.SetInt("HighScore", _newHighScore);
            _highScoreText.text = "High Score: " + _newHighScore;
        }
    }

    public void UpdateLives(float currentLives)
    {
        _livesImg.sprite = _livesSprites[(int) currentLives];
        if (currentLives <= 0)
        {
            _gameManager.GameOver();
            _gameOverText.gameObject.SetActive(true);
            StartCoroutine(GameOverFlickerRoutine());
            _deathScreenText.gameObject.SetActive(true);
        }
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    //method for resume play
    public void ResumePlayOnClick()
    {
        if (Time.timeScale == 0)
        {
            _pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    //method for back to main menu
    public void GoToMainMenuOnClick()
    {
        SceneManager.LoadScene(0);
    }
}
