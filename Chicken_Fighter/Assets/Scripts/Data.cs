using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int BestScore, TotalCoins;

    public Data(UIManager score)
    {
        TotalCoins = score.totalCoins;
        BestScore = score.finalScore;
    }
}
