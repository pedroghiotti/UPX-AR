using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Command : MonoBehaviour
{
    [SerializeField] internal Transform playerTransform;
    private Button executeButton;

    internal int runs = 1;
    private int maxRuns = 3;

    public void incrementRuns(TMP_Text textBox)
    {
        runs = runs >= maxRuns ? 1 : runs + 1;
        textBox.text = $"X{runs}";
    }
    
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        executeButton = GameObject.FindWithTag("Execute").GetComponent<Button>();

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
    public async virtual Task<bool> Execute()
    {
        return true;
    }
}
