using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, bestScoreText, finishText, totalCoinsText;
    [SerializeField] GameObject finishPanel;
    public int currentScore, finalScore, bestScore, totalCoins;

    private void Start()
    {
        scoreText.text = " 0";
        bestScoreText.text = "Best Score: " + bestScore;
        totalCoinsText.text = "Total Coins: " + totalCoins;
        finishPanel.SetActive(false);
    }
    public void AddScore(int score)
    {
        currentScore += score;
        scoreText.text = "" + currentScore;
    }
    public void FinishLevel()
    {
        finishPanel.SetActive(true);
        finalScore= currentScore;
        finishText.text = "" + finalScore;
        if (finalScore > bestScore)
        {
            bestScore = finalScore;
            bestScoreText.text = "New Best Score: " + bestScore;
        }
        else if (finalScore <= bestScore)
        {
            bestScoreText.text = "Best Score: " + bestScore;
        }
        totalCoins += finalScore;
        totalCoinsText.text = "Total Coins: " + totalCoins;
    }
}
