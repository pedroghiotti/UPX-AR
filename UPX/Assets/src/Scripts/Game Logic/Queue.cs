using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Data;
using Unity.VisualScripting;
using TMPro;

public class Queue
{
    public List<Command> lst;
    public int currentIndex;

    public Queue(List<Command> lst)
    {
        this.lst = lst;
    }

    public async Task<int> Execute(string s)
    {
        currentIndex = 0;

        while(currentIndex < lst.Count)
        {
            Debug.LogWarning($"{s}:\n\nCurrent Index: {currentIndex}, Item at current: {lst[currentIndex]}\nLastIndex: {lst.Count-1}\n\n");

            int response = await lst[currentIndex].Execute();
            currentIndex += response + 1;

            Debug.LogWarning(response);
        }

        return 0;
    }
}
