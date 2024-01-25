using UnityEngine;

public class ColliderEnableTest : MonoBehaviour {
    public int CompletionCount => IsEnabled ? (TriggerEntered ? 2 : 1) : 0;
    public bool IsEnabled => boxC.enabled;
    bool triggerEntered = false;
    public bool TriggerEntered => triggerEntered;
    private void OnTriggerEnter(Collider other) {
       if (other.gameObject.tag == "Player") triggerEntered = true;
    }
    BoxCollider boxC;
    Renderer render;
    void Awake(){
        boxC = GetComponent<BoxCollider>();
        render = GetComponent<Renderer>();
    }
    void Update(){
        Color c = render.material.color;
        if (boxC.enabled){
            render.material.color = Color.white;
        }
        else{
            render.material.color = Color.red;
        }
        // renderer.material.color = c;
    }
}