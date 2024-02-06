using UnityEngine;

public class A2T1 : Task
{
    [SerializeField] MovementTest movementTest;
    [SerializeField] JatekosMozgas player;
    public override void CheckTask()
    {
        if (!subTasks[0].isCompleted){
            if (movementTest.PlayerMoved){
                subTasks[0].completedSubTaskCount++;
                wasUpdated = true;
            }
        }
        if (!subTasks[1].isCompleted){
            if (player.gameObject.GetComponentInChildren<Camera>() != null){
                subTasks[1].completedSubTaskCount++;
                wasUpdated = true;
            }
        }
    }

    public override void SetupTask()
    {
        subTasks.Add(new SubTask("Írd meg a játékos mozgását, és próbáld ki!"));
        subTasks.Add(new SubTask("Javítsd ki a kamerát, hogy az kövesse a játékost!"));
    }
}