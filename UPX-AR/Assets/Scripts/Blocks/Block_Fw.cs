using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Block_Fw : ExecuteBlock
{
    public override async Task<bool> Execute()
    {
        await player.MoveForward();
        return true;
    }
}
