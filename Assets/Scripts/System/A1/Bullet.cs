using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [Header("Parts")]
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject casing;

    [Header("Bullet Speed")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] float casingSpeed;

    public void Shoot(Transform ejection){
        projectile.transform.parent = null;
        projectile.transform.localScale = new Vector3(5,5,5);
        projectile.GetComponent<Rigidbody>().AddForce(transform.right * -bulletSpeed, ForceMode.VelocityChange);
        
        //Drop casing in random direction
        casing.transform.parent = null;
        casing.transform.position = ejection.position;
        casing.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(casingSpeed, 0), ForceMode.Impulse);
        StartCoroutine(DestroyAfterCd());

    }

    IEnumerator DestroyAfterCd(){
        yield return new WaitForSeconds(5);
        Destroy(projectile);
        Destroy(casing);
        Destroy(gameObject);
    }

}