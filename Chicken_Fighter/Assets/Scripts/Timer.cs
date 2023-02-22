using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float currentTime = 0;
    private static Timer instance;
    public static Timer Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void CountUp(float time)
    {        
        //Debug.Log(currentTime.ToString());
        if (currentTime < (time))
        {
            currentTime += Time.deltaTime;
        }
        if (currentTime > (time))
        {
            currentTime = 0;
        }
    }
}
