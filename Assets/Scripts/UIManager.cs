using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private GameObject _deathScreenText;
    [SerializeField] private Sprite[] _livesSprites;
    [SerializeField] private Image _livesImg;
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("game manager is null");
        }
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _deathScreenText.gameObject.SetActive(false);
    }

    public void UpdateScoreOnScreen(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
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
}
