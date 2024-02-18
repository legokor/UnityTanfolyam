using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labda : MonoBehaviour
{
    [SerializeField] Rigidbody labdaRB;
    public void Meglok(){
        Vector3 ero = Vector3.forward * 10f;
        //Ide kerül a meglökés, ez legyen súlytól és időtől független  
        labdaRB.AddForce(ero, ForceMode.VelocityChange);
        //
    }
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            Meglok();
        }
    }
}
