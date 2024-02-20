using UnityEngine;

public class Faklya : MonoBehaviour{
    [Header("Ezt kapcsold be!")]
    [SerializeField] bool bekapcsolva = false;
    public bool IsOn => bekapcsolva;
    [Header("Particles")]
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