using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }
    public void UnloadLevel()
    {
        if(SceneManager.GetSceneByBuildIndex(1).isLoaded)
        {
            SceneManager.UnloadSceneAsync(1);
        }
    }
}
