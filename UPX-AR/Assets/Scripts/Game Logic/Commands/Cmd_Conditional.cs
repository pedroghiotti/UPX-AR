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

    public override async Task<bool> Execute()
    {
        return CastForCollision();
    }

    private void OnDrawGizmos()
    {
        if(!Application.isPlaying) return;
        
        Gizmos.DrawRay(playerTransform.position, playerTransform.forward * raycastLength);
    }

    internal bool CastForCollision()
    {
        return Physics.Raycast(playerTransform.position, playerTransform.forward, raycastLength, layerMask);
    }
}
