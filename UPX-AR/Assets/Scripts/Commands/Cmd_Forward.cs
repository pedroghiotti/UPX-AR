using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/*
    Herda de Command.
    Sobrescreve o método Execute, impementando uma função de movimento através
    de interpolação da posição do player.
    
    A distância e intervalo de tempo que leva a movimentação são configuráveis
    através das variáveis moveDistance e moveTime.
*/
public class Cmd_Forward : Command
{
    [Header("Settings")]
    [SerializeField] private float moveDistance = 5;
    [SerializeField] private float moveTime = 2;

    public override async Task<bool> Execute()
    {
        float t = 0;
        Vector3 stPos = playerTransform.position;
        Vector3 tgPos = stPos + playerTransform.forward * moveDistance;

        while(t < 1)
        {
            t += Time.deltaTime * (1 / moveTime);
            playerTransform.position = Vector3.Lerp(stPos, tgPos, t);
            await Task.Yield();
        }

        return true;
    }
}
