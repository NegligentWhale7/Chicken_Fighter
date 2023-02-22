using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManagement : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void LoadingScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
