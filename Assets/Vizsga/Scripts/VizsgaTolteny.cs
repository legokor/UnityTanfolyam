using System.Collections;
using UnityEngine;

public class Lovedek : MonoBehaviour {
    [Header("Részek")]
    [SerializeField] GameObject lovedek;
    [SerializeField] GameObject tolteny;

    private float lovedekSebesseg = 100f;
    float casingSpeed = 0.05f;

    public void Kilo(Transform ejection, bool permanentProjectile = false){
        lovedek.transform.parent = null;
        lovedek.transform.localScale = new Vector3(5,5,5);
        Vector3 irany = transform.right * lovedekSebesseg;

        //Adj a lövedéknek erőt az adott irányba. A ForceMode legyen tömeg és idő független!
        lovedek.GetComponent<Rigidbody>().AddForce(irany, ForceMode.VelocityChange);
        //

        tolteny.transform.parent = null;
        tolteny.transform.position = ejection.position;
        tolteny.GetComponent<Rigidbody>().AddForce(transform.right * Random.Range(casingSpeed, 0), ForceMode.Impulse);
        if (!permanentProjectile) StartCoroutine(DestroyAfterCd());

    }

    IEnumerator DestroyAfterCd(){
        yield return new WaitForSeconds(5);
        Destroy(lovedek);
        Destroy(tolteny);
        Destroy(gameObject);
    }
}