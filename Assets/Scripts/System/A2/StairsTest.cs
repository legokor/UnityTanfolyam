using System;
using UnityEngine;

public class StairsTest : MonoBehaviour {
    Vector3 SpawnPos = new Vector3(6.5f, 10, -7.7f);
    bool IsSetupCorrenctly => GetComponent<Rigidbody>() != null && GetComponent<Rigidbody>().isKinematic == false && GetComponent<Rigidbody>().useGravity == true;
    bool walkedUp = false; 
    public int GetCompletionCount => IsSetupCorrenctly ? (walkedUp ? 2 : 1) : 0;
    void Start(){
        transform.position = SpawnPos;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            walkedUp = true;
        }
    }
}