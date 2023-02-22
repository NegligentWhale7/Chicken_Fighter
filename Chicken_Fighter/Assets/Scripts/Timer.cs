using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private void Update()
    {
        Timering();
    }
    private void Timering()
    {
        float elapsedTime = 0;
        elapsedTime += Time.deltaTime;
        Debug.Log(elapsedTime);
        /*if (elapsedTime < time)
        {
            elapsedTime += Time.time;
            Debug.Log(elapsedTime);
        }
        if (elapsedTime > time)
        {
            elapsedTime = 0;
        }*/
    }
}
