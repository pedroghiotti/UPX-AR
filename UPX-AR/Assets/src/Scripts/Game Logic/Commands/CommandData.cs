using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCommand", menuName = "Command", order = 0)]
public class CommandData : ScriptableObject
{
    // Declaro como internal para que esteja disponível à classes que herdem desta.
    internal Transform playerTransform;

    /*
        Código rodado quando este comando estiver na tela.
        Retorna uma boolean para permitir a construção de comandos condicionais.
    */
    public async virtual Task<bool> Execute() 
    {
        return true;
    }
}
