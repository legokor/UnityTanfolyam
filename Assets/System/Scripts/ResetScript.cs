using System.IO;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public void ResetTasks() {
        Debug.Log("Resetting tasks...");
        File.WriteAllText(Application.persistentDataPath + "/session.txt", "0;0;0");
    }
}
