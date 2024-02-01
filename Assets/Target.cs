using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    bool hit = false; public bool Hit => hit;
    [SerializeField] float fallSpeed = 1f;
    public void OnHit(){
        if (hit) return;
        hit = true;
        StartCoroutine(Fall());
    }

    IEnumerator Fall(){
        float t = 0;
        Vector3 newRot = new Vector3(90,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z);
        while (t < 1){
            t += Time.deltaTime * fallSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newRot), t);
            yield return null;
        }
    }
}
