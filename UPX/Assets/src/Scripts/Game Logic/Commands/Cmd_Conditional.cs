using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/*
    Herda de Command.
    Sobrescreve o método Execute, impementando uma função de Raycast;
    Faz uma verificação, à partir da posição do jogador e em direção frontal dele,
    procurando por obstruções. Retornando true caso encontre e false caso não encontre.
    As obstruções são identificadas por seu layer. Para que um objeto seja detectado como obstrução,
    deve ter um colisor e estar em um dos layers definidos na layermask.

    A distância de detecção e os layers detectados são configuráveis através das variáves
    raycastLength e layerMask.
*/
public class Cmd_Conditional : Command
{
    [Header("Settings")]
    [SerializeField] private float raycastLength = 5;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool flip = true;

    public override async Task<int> Execute()
    {
        await Task.Yield();

        bool collisionFound = CastForCollision();

        if(collisionFound == flip) return 0;
        else return 1;
        
    }

    internal bool CastForCollision()
    {
        if(!playerTransform) return false;
        return Physics.Raycast(playerTransform.position, playerTransform.forward, raycastLength, layerMask);
    }

    void OnDrawGizmos()
    {
        if(!Application.isPlaying) return;
        if(!playerTransform) return;
        
        Gizmos.DrawRay(playerTransform.position, playerTransform.forward * raycastLength);
    }
}
