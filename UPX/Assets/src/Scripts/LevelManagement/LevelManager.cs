using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu()]
public class LevelManager : ScriptableObject
{
    [SerializeField] private int? loadedLevelIndex = null;

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadSceneAsync(levelIndex, LoadSceneMode.Additive);
        loadedLevelIndex = levelIndex;
    }
    public void UnloadLevel()
    {
        if(loadedLevelIndex == null || !SceneManager.GetSceneByBuildIndex(loadedLevelIndex.Value).isLoaded) return;

        SceneManager.UnloadSceneAsync(loadedLevelIndex.Value);
    }
}
