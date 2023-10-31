using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Command : MonoBehaviour
{
    internal Transform playerTransform;
    
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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
