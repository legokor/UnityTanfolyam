using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A2T4 : Task
{
    public override void CheckTask()
    {
    }

    public override void SetupTask()
    {
        subTasks.Add(new SubTask("Építs egy házat a ProBuilder használatával!"));
    }
}
