using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsPaused = true;
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
