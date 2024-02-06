using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTrigger : MonoBehaviour
{
    bool hasEntered = false; public bool HasEntered => hasEntered;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            hasEntered = true;
        }
    }
}
