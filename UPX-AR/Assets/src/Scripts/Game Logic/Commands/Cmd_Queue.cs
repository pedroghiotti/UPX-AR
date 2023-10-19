using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

[CreateAssetMenu(fileName = "NewQueue", menuName = "Cmd Queue", order = 0)]
public class Cmd_Queue : CommandData
{
    [SerializeField] private List<CommandData> queue = new();

    public void Initialize(List<CommandData> lst)
    {
        queue = lst;
    }

    public override async Task<bool> Execute()
    {
        for(int i = 0; i < queue.Count; i++)
        {
            bool response = await queue[i].Execute();
            Debug.Log(response);
            if(!response) i++;
        }

        return true;
    }
}
