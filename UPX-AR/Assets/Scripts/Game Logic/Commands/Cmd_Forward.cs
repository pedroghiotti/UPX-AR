using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using DG.Tweening;

/*
    Herda de Cmd_Conditional.
    Sobrescreve o método Execute, impementando uma função de movimento através
    de interpolação da posição do player.
    
    A distância e intervalo de tempo que leva a movimentação são configuráveis
    através das variáveis moveDistance e moveTime.

    A herança do comando condicional possibilita impedir o movimento caso
    encontre uma obstrução.
    Não é a implementação mais correta, visto que o uso do condicional foi implementado
    com intenção de ser usado de forma diferente.
    Por enquanto fica assim mas, conforme o projeto evolúi, planejo reescrever a parte
    da lógica referente à comandos condicionais de qualquer forma.
*/
public class Cmd_Forward : Cmd_Conditional
{
    [Header("Settings - Movement")]
    [SerializeField] private float moveDistance = 5;
    [SerializeField] private float moveTime = 2;
    [SerializeField] private Ease easeMode = Ease.Linear;

    public override async Task<bool> Execute()
    {
        if(CastForCollision()) return true;

        float t = 0;
        Vector3 stPos = playerTransform.position;
        Vector3 tgPos = stPos + playerTransform.forward * moveDistance;

        playerTransform.DOMove(tgPos, moveTime).SetEase(easeMode);
        
        while(t < 1)
        {
            t += Time.deltaTime * (1 / moveTime);
            // playerTransform.position = Vector3.Lerp(stPos, tgPos, t);

            await Task.Yield();
        }

        return true;
    }
}
