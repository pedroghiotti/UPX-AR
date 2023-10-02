using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class ExecuteBlock : MonoBehaviour
{
    internal PlayerAvatar player;
    private void Start()
    {
        player = FindObjectOfType<PlayerAvatar>().GetComponent<PlayerAvatar>();
    }

    public async virtual Task<bool> Execute() 
    {
        Debug.Log(this.name);
        await Task.Delay(1000);
        return true;
    }
}
