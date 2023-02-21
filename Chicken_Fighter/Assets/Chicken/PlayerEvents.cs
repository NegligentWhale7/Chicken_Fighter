using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    [SerializeField] UnityEvent onDeath, onScore;
    [SerializeField] UIManager uI;
    
    private void OnTriggerEnter(Collider other)
    {
        if (onDeath == null)
        {
            return;
        }
        if (other.CompareTag("Dangerous"))
        {
            onDeath.Invoke();
        }
        if (other.CompareTag("Coin"))
        {
            onScore.Invoke();
            Score score = other.GetComponent<Score>();
            score.CheckCoinValue();
            uI.AddScore(score.CheckCoinValue());
        }
    }    

}
