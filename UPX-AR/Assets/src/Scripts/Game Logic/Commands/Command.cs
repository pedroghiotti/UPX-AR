using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

/*
    A classe base dos blocos de comando.
    Contém uma referência ao transform do player e um método virtual 'Execute'
    que será chamado pelo CommandManager ao rodar a lógica do game;
    Deve ser sobrescrito em classes filhas para rodar a lógica desejada.

    Essa classe e classes filhas devem ser utilizadas como componentes e atreladadas aos
    image targets do vuforia.

    Entre hereditariedade e composição (interfaces), escolhi utilizar hereditariedade
    pois não parece haver necessidade de composição para o desenvolvimento desse sistema.
*/
public class Command : MonoBehaviour
{
    [SerializeField] public CommandData commandData;

    /*
        Awake -> Método da Unity, roda antes mesmo do Start na criação do objeto.
        Busco pelo objeto marcado como "Player" (usando a tag do GameObject).
    */
    private void Awake()
    {
        commandData.playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
