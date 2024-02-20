using UnityEngine;

public class RayCaster : MonoBehaviour {
    
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            Raycast();
        }
    }

    void Raycast(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float distance = 100f;
        LayerMask reteg = LayerMask.GetMask("Labda");
        if (false /*Ide jön a raycast az ezt megelőző paraméterekkel*/){
            if (hit.collider.gameObject.CompareTag("Labda")){
                //Ide jön a labda meglökése

                //
            }
        }
    }
}