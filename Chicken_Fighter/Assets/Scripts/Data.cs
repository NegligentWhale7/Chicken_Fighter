using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public int BestScore, FinalScore, TotalCoins;

    public PlayerData(UIManager score)
    {
        FinalScore = UIManager.finalScore;
        BestScore = UIManager.finalScore;
    }
}
