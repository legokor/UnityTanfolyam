using UnityEngine;

public class ToggleTest : MonoBehaviour{
    [SerializeField] bool bekapcsolva = false;
    public bool IsOn => bekapcsolva;
    [SerializeField] ParticleSystem fire;
    [SerializeField] ParticleSystem smoke;

    void Update(){
        if (bekapcsolva){
            fire.Play();
            smoke.Play();
        }
        else{
            fire.Stop();
            smoke.Stop();
        }
    }
}