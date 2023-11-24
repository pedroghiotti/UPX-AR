using System;
using System.Data;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class Cmd_For : Command
{
    [SerializeField] internal TMP_Text runCount;
    internal int runs = 1;
    private int maxRuns = 3;
    private int span = 1;

    private CommandManager commandManager;

    void Awake()
    {
        commandManager = FindObjectOfType<CommandManager>();
    }
    public void incrementRuns(int n)
    {
        runs = runs >= maxRuns ? 1 : runs + n;
        runCount.text = $"X{runs}";
    }

    public override async Task<int> Execute()
    {
        int currentIndex = commandManager.queue.currentIndex;
        List<Command> lst = new(); lst.Add(commandManager.queue.lst[currentIndex+1]);
        commandManager.queue.lst.RemoveAt(currentIndex+1);
        // List<Command> lst = commandManager.queue.lst.GetRange(currentIndex + 1, currentIndex + span);
        // commandManager.queue.lst.RemoveRange(currentIndex + 1, currentIndex + span);
        Queue queue = new(lst);

        for(int i = 0; i < runs; i++)
        {
            await queue.Execute("For");
        }

        return 0;
    }
}
