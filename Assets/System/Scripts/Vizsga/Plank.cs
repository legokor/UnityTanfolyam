using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    [SerializeField] GameObject weight;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null) return;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        rb.centerOfMass = new Vector3(0, -1.5f, 0);
    }

    void Update()
    {
        if (weight.GetComponent<Rigidbody>() != null && weight.GetComponent<Rigidbody>().mass >= 150)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb == null) return;
            if (transform.rotation.eulerAngles.x <= 344 && transform.rotation.eulerAngles.x >= 340) rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    } 

}
