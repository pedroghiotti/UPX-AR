using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

/*
    Classe responsável por manter uma lista atualizada dos objetos trackeados pelo vuforia
    e executar os comandos correspondentes à eles.
*/
public class CommandManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> tracked = new List<GameObject>();

    public void AddTracked(GameObject obj) { tracked.Add(obj); }
    public void RemoveTracked(GameObject obj) { tracked.Remove(obj); }

    /*
        A função Execute irá organizar os comandos da esquerda para a direita,
        como estiverem dispostas fisicamente as imagens detectadas, e executá-los sequencialmente.

        A implementação de condicionais aqui é bem protótipo do protótipo então vou ter que reescrever
        a funcionalidade quando formos adicionar loops ou condicionais maiores. No momento, apenas pula ou executa
        o comando diretamente após um condicional com base no seu retorno (false ou true). A condição deve ser
        verificada diretamente no código do comando que deverá retornar o resultado
        (ver Cmd_Conditional.cs como exemplo).

        Esse trecho entre colchetes antes do método permite que seja executado do editor,
        através de uma opção no menu contextual nos três pontinhos na extremidade direita do componente.

        TODO: Implementar condição de parada para loop da lógica definida pelo jogador.

    */
    [ContextMenu("Execute")]
    public async void Execute()
    {
        if(tracked.Count == 0) return;

        /*
            Organizo em ordem da esquerda para a direita e busco, 
            nos gameobjects, os componentes dos comandos.
        */
        var commandsQueue = tracked.OrderBy(obj => obj.transform.position.x).Select(obj => obj.GetComponent<Command>()).ToList();

        while(true) // <- TODO: Implementar condição de parada.
        {
            if(!Application.isPlaying) break; // Somente relevante para execução no editor.

            for(int i = 0; i < commandsQueue.Count(); i++)
            {
                bool response = await commandsQueue[i].Execute();
                if(!response) i++;
            }

            await Task.Yield();
        }
    }
}
