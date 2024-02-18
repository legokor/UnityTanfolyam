using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [Header("Parts")]
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject casing;

    [Header("Bullet Speed")]
    private float bulletSpeed = 100f;
    float casingSpeed = 0.05f;

    public void Shoot(Transform ejection){
        projectile.transform.parent = null;
        projectile.transform.localScale = new Vector3(5,5,5);
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed * 0.001f, ForceMode.VelocityChange);
        
        //Drop casing in random direction
        casing.transform.parent = null;
        casing.transform.position = ejection.position;
        casing.GetComponent<Rigidbody>().AddForce(transform.right * Random.Range(casingSpeed, 0), ForceMode.Impulse);
        StartCoroutine(DestroyAfterCd());

    }
    public void DestroySelf(){
        Destroy(projectile);
        Destroy(casing);
        Destroy(gameObject);
    
    }
    IEnumerator DestroyAfterCd(){
        yield return new WaitForSeconds(5);
        DestroySelf();
    }

}