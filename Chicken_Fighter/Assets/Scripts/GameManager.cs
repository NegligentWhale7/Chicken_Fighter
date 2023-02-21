using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsPaused = true;
    [SerializeField] UIManager uI;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
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
    public void SaveScore()
    {

    }
}
