using UnityEngine;

public class A2T2 : Task {
    [SerializeField] StairsTest Stairs;
    [SerializeField] GameObject Ball;
    [SerializeField] BallTarget BallTarget;

    public override void CheckTask()
    {
        Rigidbody rb = Ball.GetComponent<Rigidbody>();
        if (subTasks[0].completedSubTaskCount != Stairs.GetCompletionCount){
            subTasks[0].completedSubTaskCount = Stairs.GetCompletionCount;
            wasUpdated = true;
        }
        if (!subTasks[1].isCompleted){
            if (rb != null && Ball.GetComponent<Rigidbody>().isKinematic == false && Ball.GetComponent<Rigidbody>().useGravity == true){
                subTasks[1].completedSubTaskCount++;
                wasUpdated = true;
            }
        }
        int completionCount = 0;
        if (rb != null && rb.constraints == RigidbodyConstraints.FreezePositionZ){
            completionCount = BallTarget.IsIn ? 2 : 1;
        }
        if (subTasks[2].completedSubTaskCount != completionCount){
            subTasks[2].completedSubTaskCount = completionCount;
            wasUpdated = true;
        }
    }

    public override void SetupTask()
    {
        subTasks.Add(new SubTask("Oldd meg, hogy a lépcső leessen a helyére, és menj fel rajta!", 2));
        subTasks.Add(new SubTask("Tedd lehetővé, hogy a játékos mozgathassa a gömböt!"));
        subTasks.Add(new SubTask("Találd meg a megfelelő beállítást arra, hogy a gömb ne essen le oldalt a rámpáról, majd lökd le a célba!", 2));

    }
}