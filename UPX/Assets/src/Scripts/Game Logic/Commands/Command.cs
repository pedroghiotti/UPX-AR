using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System;

public class Command : MonoBehaviour
{
    internal Transform playerTransform;

    [SerializeField] private Button executeButton;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // executeButton = GameObject.FindWithTag("Execute").GetComponent<Button>();

        Button[] buttons = GetComponentsInChildren<Button>();

        if(buttons.Length <= 0 && executeButton != null) return;

        foreach(Button button in buttons)
        {
            executeButton.onClick.AddListener(() => button.interactable = false);
        }
    }
    
    /*
        Código rodado quando este comando estiver na tela.
        Retorna uma boolean para permitir a construção de comandos condicionais.
    */
    public async virtual Task<int> Execute()
    {
        await Task.Yield();
        return 0;
    }
}
