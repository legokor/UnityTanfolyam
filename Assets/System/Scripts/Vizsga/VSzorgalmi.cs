using UnityEngine;

public class VSzorgalmi : Task {
    public override void CheckTask()
    {

    }

    public override void SetupTask()
    {
        subTasks.Add(new SubTask("Szorgalmi: készítsd el a Schönherz kollégium épületét ProBuilder használatával!"));
    }
}