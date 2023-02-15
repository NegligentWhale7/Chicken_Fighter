using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsPaused = true;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void Pause()
    {
        if (IsPaused)
        {
            IsPaused= false;
        }
        else
        {
            IsPaused= true;
        }
    }
}
