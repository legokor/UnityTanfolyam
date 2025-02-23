using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ResetScript))]
public class ExampleScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ResetScript script = (ResetScript)target;

        // Disable button in Play Mode
        GUI.enabled = !Application.isPlaying;

        if (GUILayout.Button("Feladatok teljesítésének visszaállítása"))
        {
            script.ResetTasks();
        }

        // Re-enable GUI after button
        GUI.enabled = true;
    }
}