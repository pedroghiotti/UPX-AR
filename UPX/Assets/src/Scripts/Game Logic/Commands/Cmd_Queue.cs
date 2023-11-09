using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Data;
using Unity.VisualScripting;

public class Cmd_Queue : Command
{
    [SerializeField] private List<Command> queue = new();

    public void Initialize(List<Command> lst)
    {
        queue = lst;
    }

    void Start()
    {
        queue.ForEach((command) => command.playerTransform = this.playerTransform);
    }

    public override async Task<bool> Execute()
    {
        for(int i = 0; i < runs; i++)
        {
            for(int j = 0; j < queue.Count; j++)
            {
                bool response = await queue[j].Execute();
                if(!response) j++;
            }
        }

        return true;
    }
}
