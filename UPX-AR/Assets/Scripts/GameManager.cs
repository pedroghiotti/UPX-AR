using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> onCamera = new List<GameObject>();

    public void AddObj(GameObject obj)
    {
        onCamera.Add(obj);
    }
    public void RemoveObj(GameObject obj)
    {
        onCamera.Remove(obj);
    }

    [ContextMenu("Execute")]
    public async void Execute()
    {
        var lst = new List<GameObject>(onCamera).OrderBy(obj => obj.transform.position.x);

        foreach(var obj in lst)
        {
            await obj.GetComponent<ExecuteBlock>().Execute();
        }
    }
}
