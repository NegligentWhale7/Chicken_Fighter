using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsPaused = true;
    [SerializeField] UIManager uI;
    [SerializeField] GameObject finishPanel;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    private void Update()
    {
        if(finishPanel.activeSelf)
        {
            IsPaused = true;
        }
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
