using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIGameController : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameController gameController;
    [SerializeField] private ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = gameController.ActualTime.ToString();
        scoreText.text = scoreManager.GlobalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = gameController.ActualTime.ToString();
        scoreText.text = "Score: " + scoreManager.GlobalScore.ToString();
    }
}
