using UnityEngine;

public class BallTarget : MonoBehaviour {
    public bool IsIn { get; private set; } = false;
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Labda"))
        {
            IsIn = true;
        }
    }
}