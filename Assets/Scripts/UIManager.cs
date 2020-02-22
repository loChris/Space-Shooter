using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //create a handle to Text
    [SerializeField] private Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //assign text component to handle to use it
        _scoreText.text = "Score: " + 0;
    }

    public void UpdateScoreOnScreen(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }
}
