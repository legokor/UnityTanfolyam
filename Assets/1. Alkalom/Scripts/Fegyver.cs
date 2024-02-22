using System;
using UnityEngine;

public class Fegyver : MonoBehaviour {

    [Header("Sway Settings")]
    [SerializeField]  float smooth;
    [SerializeField]  float multiplier;
    [Header("Ide rakd be a lövedék Prefabot!")]
    [SerializeField]  GameObject ToltenyPrefab;
    [Header("Parts")]
    [SerializeField]  Transform cso;
    [SerializeField] Transform ejection;
    [SerializeField] float shootCd;
    float shootCdTimer = 0;

    public bool HasBullet => ToltenyPrefab != null;


    void Loves(){
        if (this.ToltenyPrefab == null) return;
        GameObject tolteny = null;

        //Itt példányosítsd a ToltenyPrefab-ot a cso pozíciójában és elforgatásában
        tolteny = Instantiate(ToltenyPrefab, cso.position, cso.rotation);
        //

        if (tolteny == null) return;
        tolteny.GetComponent<Bullet>().Shoot(ejection);
        
    }



    private void Update()
    {
        //Sway
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * multiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * multiplier;

        // calculate target rotation
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        // rotate 
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

        if (Input.GetMouseButton(0) && shootCdTimer > shootCd)
        {
            Loves();
            shootCdTimer = 0;
        }
        shootCdTimer += Time.deltaTime;
    }

}
