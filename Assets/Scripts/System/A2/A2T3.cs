using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class A2T3 : Task
{
    [SerializeField] GameObject ballTargetPrefab;
    [SerializeField] List<BallTarget> ballTargets;
    [SerializeField] BallTarget testTarget;
    public override void CheckTask()
    {
        if (!subTasks[0].isCompleted){
            if (!Physics.GetIgnoreLayerCollision(LayerMask.NameToLayer("Default"), LayerMask.NameToLayer("Labda"))){
                subTasks[0].completedSubTaskCount++;
                wasUpdated = true;
            }
        }
        if (!subTasks[1].isCompleted){
            foreach (var child in ballTargetPrefab.transform){
                Transform c = (Transform)child;
                if (c.name == "Labda" && c.gameObject.tag == "Labda"){
                    subTasks[1].completedSubTaskCount++;
                    wasUpdated = true;
                }
            }
        }
        if (!subTasks[2].isCompleted){
            if (testTarget.IsIn){
                subTasks[2].completedSubTaskCount++;
                wasUpdated = true;
            }
        }
        int ballInBox = ballTargets.Where(x=>x.IsIn).Count();
        if (subTasks[3].completedSubTaskCount != ballInBox){
            subTasks[3].completedSubTaskCount = ballInBox;
            wasUpdated = true;
        }
    }

    public override void SetupTask()
    {
        subTasks.Add(new SubTask("Állítsd be, hogy a Labda és a Default rétegek közötti ütközés szimulálva legyen!"));
        subTasks.Add(new SubTask("Módosítsd úgy a LabdaGól elemet, hogy a Labda a megfelelő címkét kapja!"));
        subTasks.Add(new SubTask("Valósítsd meg, hogy a Labda szkript Meglok() függvénye belökje a labdát a dobozba!"));
        subTasks.Add(new SubTask("Írd meg a RayCaster szkript hiányzó függvényét, majd használatával lökd be a labdákat a dobozba!", 3));
    }
}