using UnityEngine;

public class DebugTest : MonoBehaviour {
    int i = 1;

    //Ide írd a Start függvényt, amely kiírja figyelmeztetés konzolra, hogy "Hello World!"
    void Start(){
        Debug.LogWarning("Hello World!");
    }
    //


    //Ide írd az Update függvényt, amely kiírja információ konzolra 1-től 10-ig a számokat!
    void Update(){
        if (i <= 10){
            Debug.Log(i);
            i++;
        }
    }
    //




    public void TestStart(){
        //if start function exists, call it
        if (GetType().GetMethod("Start") != null){
            GetType().GetMethod("Start").Invoke(this, null);
        }
    }
}