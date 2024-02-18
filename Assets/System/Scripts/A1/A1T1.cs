using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A1T1 : Task
{   
    [Header("SubTask Elements")]
    [SerializeField] ToggleTest toggle;
    [SerializeField] ColliderTest colliderTest;
    [SerializeField] ColliderEnableTest colliderEnableTest;
    public override void CheckTask()
    {
        if (subTasks[0].completedSubTaskCount != colliderEnableTest.CompletionCount){
            subTasks[0].completedSubTaskCount = colliderEnableTest.CompletionCount;
            wasUpdated = true;
        }
        if (toggle.IsOn && !subTasks[1].isCompleted){
            subTasks[1].completedSubTaskCount++;
            wasUpdated = true;
        }
        if (colliderTest.IsFlagInTrigger && !subTasks[2].isCompleted){
            subTasks[2].completedSubTaskCount++;
            wasUpdated = true;
        }
    
    }

    public override void SetupTask()
    {
        subTasks.Add(new SubTask("Kapcsold be a híd Colliderét, és menj át rajta!", 2));
        subTasks.Add(new SubTask("Kapcsold be a fáklyát!"));
        subTasks.Add(new SubTask("Helyezd a zászlót a torony tetejére!"));
    }

}
