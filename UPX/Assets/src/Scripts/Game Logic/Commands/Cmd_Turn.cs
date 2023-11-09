using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/*
    Herda de Command.
    Sobrescreve o método Execute, impementando uma função de rotação através
    de interpolação da rotação do player.
    
    A distância e intervalo de tempo que leva a rotação são configuráveis
    através das variáveis rotDistance e rotTime.
*/
public class Cmd_Turn : Command
{
    [Header("Settings")]
    [SerializeField] private float rotDistance = 90;
    [SerializeField] private float rotTime = .5f;

    public void setRot(float rot)
    {
        rotDistance = rot;
    }

    public override async Task<bool> Execute()
    {
        for(int i = 0; i < runs; i++)
        {
            float t = 0;
            float rotY;
            float stRotY = playerTransform.rotation.eulerAngles.y;
            float tgRotY = stRotY + rotDistance;

            while(t < 1)
            {
                t += Time.deltaTime * (1 / rotTime);

                if(!playerTransform) break;

                rotY = Mathf.Lerp(stRotY, tgRotY, t);
                playerTransform.rotation = Quaternion.Euler(0, rotY, 0);
                await Task.Yield();
            }
        }

        return true;
    }
}
