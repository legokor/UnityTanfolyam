using UnityEngine;

public class DebugTest : MonoBehaviour {
    int i = 0;
    void Start(){
        Debug.LogWarning("Hello World!");
    }
    void Update(){
        if (i < 10) Debug.Log(++i);
    }




    public void TestStart(){
        Start();
    }
}