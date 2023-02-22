using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, finishText;
    [SerializeField] GameObject finishPanel;
    public int currentScore, finalScore;

    private void Start()
    {
        scoreText.text = " 0";
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
    }
}
