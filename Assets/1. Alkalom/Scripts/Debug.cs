using UnityEngine;

public class Debug : MonoBehaviour {
    int i = 0;

    //Ide írd a Start függvényt, amely kiírja konzolra, hogy "Hello World!"
    void Start(){
        UnityEngine.Debug.LogWarning("Hello World!");
    }
    //


    //Ide írd az Update függvényt, amely kiírja 1-től 10-ig a számokat!
    void Update(){
        if (i < 10) UnityEngine.Debug.Log(++i);
    }
    //




    public void TestStart(){
        Start();
    }
}