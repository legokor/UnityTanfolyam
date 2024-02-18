using UnityEngine;

public class Projectile : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponentInParent<Target>() != null){
            other.gameObject.GetComponentInParent<Target>().OnHit();
        }
        Destroy(gameObject);
    }
}