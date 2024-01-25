using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColliderTest : MonoBehaviour {
    [SerializeField] GameObject flag;
    bool isFlagInTrigger = false;
    public bool IsFlagInTrigger => isFlagInTrigger;
    Bounds selfBounds;
    Bounds flagBounds;
    private void Awake(){
        selfBounds = GetComponent<Collider>().bounds;
        flagBounds = flag.GetComponent<Collider>().bounds;
    }
    void Update(){
        isFlagInTrigger = selfBounds.Intersects(flagBounds);
    }
}