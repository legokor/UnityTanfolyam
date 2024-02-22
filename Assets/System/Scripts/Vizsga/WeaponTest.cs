using UnityEngine;

public class WeaponTest : MonoBehaviour {
    public bool TestWeapon(VizsgaFegyver fegyver) {
        GameObject bullet = fegyver.Loves(true);
        if (bullet == null) return false;
        bullet.GetComponent<Lovedek>().DestroySelf();
        return true;
    }
}