using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class LevelScore : MonoBehaviour
{
    CommandManager commandManager;
    LevelManager levelManager;
    TMP_Text text;

    [SerializeField] int[] baseScore;
    void Awake()
    {
        commandManager = FindObjectOfType<CommandManager>();
        levelManager = FindObjectOfType<LevelManager>();
        text = this.GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = (baseScore[levelManager.currentLevel] - commandManager.scoreDeductor).ToString();
    }
}
