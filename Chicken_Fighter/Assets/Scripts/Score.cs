using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] Coin coin;
    public int CheckCoinValue()
    {
        Debug.Log(coin.CoinValue);
        return coin.CoinValue;
    }
}
