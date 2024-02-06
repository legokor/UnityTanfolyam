using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class A1T3 : Task
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject weaponPrefab;
    Weapon weapon;
    [SerializeField] TargetManager TargetManager;
    public override void CheckTask()
    {
        if (!subTasks[0].isCompleted){
            if (weapon.HasBullet){
                subTasks[0].completedSubTaskCount++;
                wasUpdated = true;
            }
        }
        if (subTasks[1].completedSubTaskCount != TargetManager.ShotTargets){
            subTasks[1].completedSubTaskCount = TargetManager.ShotTargets;
            wasUpdated = true;
        }
    }

    public override void SetupTask()
    {
        var w = Instantiate(weaponPrefab, PlayerController.Player.playerCamera.transform);
        weapon = w.GetComponentInChildren<Weapon>();
        subTasks.Add(new SubTask("Hozz létre prefabot az asztalon található Lövedék-ből, és add át a Fegyver megfelelő változójának!"));
        subTasks.Add(new SubTask("Módosítsd a Fegyver osztályt, hogy a Loves függvény hozza létre a lövedéket, majd lődd le az 5 céltáblát!", 5));
    }
}
