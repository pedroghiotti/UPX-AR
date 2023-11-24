using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Transform playerTransform;   
    private int activeLevelIndex = -1;
    public int currentLevel = -1;
    [SerializeField] private GameObject[] levels;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void LoadNext()
    {
        UnloadActive();
        LoadLevel(currentLevel + 1);
    }
    public void LoadCurrent()
    {
        if(currentLevel < 0) LoadNext();
        else LoadLevel(currentLevel);
    }
    public void LoadLevel(int levelIndex)
    {
        if(levelIndex < 0 || levelIndex >= levels.Length)
        {
            activeLevelIndex = -1;
            return;
        }

        levels[levelIndex].SetActive(true);
        activeLevelIndex = levelIndex;
        currentLevel = levelIndex;

        SpawnPlayer();
    }

    public void UnloadActive()
    {
        UnloadLevel(activeLevelIndex);
    }
    public void UnloadLevel(int levelIndex)
    {
        if(levelIndex < 0 || levelIndex >= levels.Length) return;

        levels[levelIndex].SetActive(false);
        activeLevelIndex = -1;
    }

    private void SpawnPlayer()
    {
        Transform spawnPoint = levels[activeLevelIndex].transform.GetChild(0);

        playerTransform.position = spawnPoint.position;
        playerTransform.rotation = spawnPoint.rotation;

        playerTransform.gameObject.SetActive(true);
    }
    
}
