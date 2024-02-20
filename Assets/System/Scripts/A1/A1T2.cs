using System;
using UnityEngine;

public class A1T2 : Task
{
    [SerializeField] DebugTest debugTest;
    public override void CheckTask()
    {
        if (!subTasks[0].isCompleted) debugTest.TestStart();
    }
    public override void SetupTask()
    {
        subTasks.Add(new SubTask("Írd ki a DebugTest osztály Start metódusában figyelmeztetés szinten, hogy \"Hello World!\"!"));
        subTasks.Add(new SubTask("A DebugTest osztály Update metódusa írjon ki minden frameben egy számot, 1-től kezdve, 10-ig!", 10));
        Application.logMessageReceived += logMessageReceived;
    }

    private void logMessageReceived(string logString, string stackTrace, LogType type)
    {
        switch(type){
            case LogType.Warning: {
                if (logString == "Hello World!" && !subTasks[0].isCompleted) 
                {
                    wasUpdated = true;
                    subTasks[0].completedSubTaskCount++;
                }
                else if (subTasks[0].completedSubTaskCount != 0) 
                {
                        UnityEngine.Debug.LogError("else if");
                    wasUpdated = true;
                    subTasks[0].completedSubTaskCount = 0;
                }
            } break;
            case LogType.Log:
            {
                if (Int32.TryParse(logString, out int num)){
                    if (num == subTasks[1].completedSubTaskCount + 1 && num < 11){
                        wasUpdated = true;
                        subTasks[1].completedSubTaskCount++;
                    }
                    else if (subTasks[1].completedSubTaskCount != 0) {
                        wasUpdated = true;
                        subTasks[1].completedSubTaskCount = 0;
                    }
                }
            } break;
            default: {
                    UnityEngine.Debug.Log($"LogType: {type} LogString: {logString} StackTrace: {stackTrace}");
            } break;
        }
    }
}