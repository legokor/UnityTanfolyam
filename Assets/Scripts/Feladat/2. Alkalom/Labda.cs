using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labda : MonoBehaviour
{
    [SerializeField] Rigidbody labdaRB;
    public void Meglok(){
        //Ide kerül a meglökés kódja
        labdaRB.AddForce(Vector3.forward *10f, ForceMode.VelocityChange);
    }
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            Meglok();
        }
    }
}
