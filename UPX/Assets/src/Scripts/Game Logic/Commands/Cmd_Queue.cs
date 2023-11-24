using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Data;
using Unity.VisualScripting;

public class Cmd_Queue : Command
{
    public Queue queue;
    public List<Command> lst;
    
    void Awake()
    {
        queue = new(lst);
    }

    public override async Task<int> Execute()
    {
        await queue.Execute("Forward");
        return 0;
    }
}
