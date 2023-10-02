using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Block_Turn : ExecuteBlock
{
    public override async Task<bool> Execute()
    {
        await player.TurnRight();
        return true;
    }
}
