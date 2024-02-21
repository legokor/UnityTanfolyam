using UnityEngine;

public class VizsgaFegyver : MonoBehaviour {
    [Header("Sway Settings")]
    [SerializeField]  float smooth;
    [SerializeField]  float multiplier;
    [Header("Bullet")]
    [SerializeField]  GameObject lovedek;
    [SerializeField]  Transform cso;
    [SerializeField] Transform nyilas;
    [SerializeField] float shootCd;
    float shootCdTimer = 0;

    public bool HasBullet => lovedek != null;


    public GameObject Loves(bool ignoreCooldown = false){
        if (shootCdTimer <= shootCd && !ignoreCooldown) return null;
        if (lovedek == null) return null;
        GameObject lovedekPeldany = null; //Ebbe kerül a lövedék példánya

        //Hozz létre egy példányt a lövedékből a cső pozíciójában és elforgatásában

        //
        

        if (lovedekPeldany == null) return null;

        //Hívd meg a lövedék Lőszer komponensének Loves() függvényét a nyilas paraméterrel

        //

        
        shootCdTimer = 0;

        return lovedekPeldany;
    }



    private void Update()
    {
        //Bal kattintás hatására lőjön a Loves() függvény segítségével
        if (Input.GetMouseButton(0))
        {
            Loves();
        }


        float mouseX = Input.GetAxisRaw("Mouse X") * multiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * multiplier;
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion targetRotation = rotationX * rotationY;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        shootCdTimer += Time.deltaTime;
    }
}