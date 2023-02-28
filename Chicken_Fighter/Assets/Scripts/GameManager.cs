using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static bool IsPaused = true;
    [SerializeField] UIManager uiManager;
    [SerializeField] GameObject finishPanel;
    [SerializeField] int targetFrameRate;
    [SerializeField] UnityEvent gameStart, gameOver;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.SetResolution(1920, 1080, true, 60);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
        Loading();
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
    public void SaveScore(UIManager scoreDt)
    {
        SaveSystem.SaveData(scoreDt);
    }
    public void Loading()
    {
        Data plyrData = SaveSystem.LoadData();
        uiManager.totalCoins = plyrData.TotalCoins;
        uiManager.bestScore = plyrData.BestScore;
    }
}
