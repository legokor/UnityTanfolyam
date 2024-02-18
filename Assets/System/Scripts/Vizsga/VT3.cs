using UnityEngine;

public class V3 : Task
{
    [SerializeField] GameObject weaponPrefab;
    VizsgaFegyver weapon;
    [SerializeField] TargetManager TargetManager;
    [SerializeField] WeaponTest weaponTest;
    public override void CheckTask()
    {
        if (!subTasks[0].isCompleted){
            if (weapon.HasBullet){
                subTasks[0].completedSubTaskCount++;
                wasUpdated = true;
            }
        }
        if (subTasks[1].isCompleted){
            if (weapon != null && weaponTest.TestWeapon(weapon)){
                subTasks[1].completedSubTaskCount++;
                wasUpdated = true;
            }
        }
        if (subTasks[2].completedSubTaskCount != TargetManager.ShotTargets){
            subTasks[2].completedSubTaskCount = TargetManager.ShotTargets;
            wasUpdated = true;
        }
    }

    public override void SetupTask()
    {
        var w = Instantiate(weaponPrefab, PlayerController.Player.playerCamera.transform);
        weapon = w.GetComponentInChildren<VizsgaFegyver>();
        subTasks.Add(new SubTask("Hozz létre prefabot az asztalon található Lövedék-ből, és add át a VizsgaFegyverRendszer megfelelő változójának!"));
        subTasks.Add(new SubTask("Módosítsd a Fegyver osztályt, hogy a Loves függvény hozza létre a töltényt!"));
        subTasks.Add(new SubTask("Egészítsd ki a VizsgaTolteny osztály Kilo() függvényét, hogy kilője a lövedéket, majd lődd le a célpontokat!", 5));
    }
}