using UnityEngine;

public class VT2 : Task
{
    [SerializeField] GameObject seesawPlane;
    [SerializeField] GameObject seesawPivot;
    [SerializeField] GameObject seesawWeight;
    [SerializeField] MovementTrigger floorEnterTrigger;

    public override void CheckTask()
    {
        if (!subTasks[0].isCompleted){
            if (seesawPlane.GetComponent<Rigidbody>() != null){
                subTasks[0].completedSubTaskCount++;
                wasUpdated = true;
            }
        }
        if (!subTasks[1].isCompleted){
            if (seesawPivot.GetComponent<Rigidbody>() != null && seesawPivot.GetComponent<Rigidbody>().isKinematic){
                subTasks[1].completedSubTaskCount++;
                wasUpdated = true;
            }
        }
        if (!subTasks[2].isCompleted){
            if (seesawWeight.GetComponent<Rigidbody>() != null && seesawWeight.GetComponent<Rigidbody>().mass >= 150){
                subTasks[2].completedSubTaskCount++;
                wasUpdated = true;
            }
        }
        if (!subTasks[3].isCompleted){
            if (floorEnterTrigger.HasEntered){
                subTasks[3].completedSubTaskCount++;
                wasUpdated = true;
            }
        }
    }

    public override void SetupTask()
    {
        subTasks.Add(new SubTask("Tedd fizikai elemmé a libikóka lapját!"));
        subTasks.Add(new SubTask("Oldd meg, hogy a libikóka csuklója ne mozogjon, de fizikai elemekkel ütközhessen!"));
        subTasks.Add(new SubTask("Állíts be elegendő súlyt a kockának, hogy fel tudj menni a libikókán!"));
        subTasks.Add(new SubTask("Végül menj fel a libikókán!"));
    }
}