using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    [SerializeField] int session;
    [SerializeField] List<Task> tasks = new List<Task>();
    List<TextMeshProUGUI> taskTexts = new List<TextMeshProUGUI>();
    int currentTaskIndex;
    // Start is called before the first frame update
    void Start()
    {
        if(File.Exists(Application.persistentDataPath + "/session.txt"))
        {
            string sessionString = File.ReadAllText(Application.persistentDataPath + "/session.txt");
            currentTaskIndex= int.Parse(sessionString.Split(";")[session-1]);
        }
        else
        {
            File.WriteAllText(Application.persistentDataPath + "/session.txt", "0;0;0");
            currentTaskIndex = 0;
        }
        if (currentTaskIndex < tasks.Count)
        {
            return;
        }
        SetupCurrentTask();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTaskIndex >= tasks.Count) return;
        if (tasks[currentTaskIndex].WasUpdated)
        {
            for (int i = 0; i < taskTexts.Count; i++){
                taskTexts[i].text = tasks[currentTaskIndex].GetTaskList()[i].ToString();
                taskTexts[i].fontStyle = tasks[currentTaskIndex].GetTaskList()[i].isCompleted ? FontStyles.Strikethrough : FontStyles.Normal;
            }
        }
        if (tasks[currentTaskIndex].IsCompleted()){
            currentTaskIndex++;
            if (currentTaskIndex >= tasks.Count) return;
            tasks[currentTaskIndex].SetupTask();
            string[] sessionStrings = File.ReadAllText(Application.persistentDataPath + "/session.txt").Split(";");
            sessionStrings[session-1] = currentTaskIndex.ToString();
            File.WriteAllText(Application.persistentDataPath + "/session.txt", string.Join(";", sessionStrings));
        }
        else {
            tasks[currentTaskIndex].CheckTask();
        }
    }

    void SetupCurrentTask(){
        tasks[currentTaskIndex].SetupTask();
        //Create the task texts in top left corner
        foreach (TextMeshProUGUI taskText in taskTexts)
        {
            Destroy(taskText.gameObject);
        }
        taskTexts.Clear();

        foreach (SubTask subTask in tasks[currentTaskIndex].GetTaskList())
        {
            GameObject taskTextObject = new GameObject("TaskText" + taskTexts.Count);
            taskTextObject.transform.SetParent(transform);
            taskTextObject.transform.localPosition = new Vector3(0, -taskTexts.Count * 30, 0);
            TextMeshProUGUI taskText = taskTextObject.AddComponent<TextMeshProUGUI>();
            taskText.text = subTask.ToString();
            taskText.fontSize = 20;
            taskText.color = Color.black;
            taskText.fontStyle = subTask.isCompleted ? FontStyles.Strikethrough : FontStyles.Normal;
            taskTexts.Add(taskText);
        }
    }
}
