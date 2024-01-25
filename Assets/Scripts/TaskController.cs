using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject TaskText;
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
            currentTaskIndex= int.Parse(sessionString.Split(";")[session]);
        }
        else
        {
            File.WriteAllText(Application.persistentDataPath + "/session.txt", "0;0;0");
            currentTaskIndex = 0;
        }
        SetupCurrentTask();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTaskIndex >= tasks.Count) return;
        Debug.Log(currentTaskIndex);
        if (tasks[currentTaskIndex].WasUpdated)
        {
            for (int i = 0; i < taskTexts.Count; i++){
                taskTexts[i].text = tasks[currentTaskIndex].GetTaskList[i].ToString();
                taskTexts[i].fontStyle = tasks[currentTaskIndex].GetTaskList[i].isCompleted ? FontStyles.Strikethrough : FontStyles.Normal;
            }
        }
        if (tasks[currentTaskIndex].IsCompleted()){
            currentTaskIndex++;
            if (currentTaskIndex >= tasks.Count) return;
            tasks[currentTaskIndex].SetupTask();
            string[] sessionStrings = File.ReadAllText(Application.persistentDataPath + "/session.txt").Split(";");
            sessionStrings[session] = currentTaskIndex.ToString();
            File.WriteAllText(Application.persistentDataPath + "/session.txt", string.Join(";", sessionStrings));
        }
        else {
            tasks[currentTaskIndex].CheckTask();
        }
    }

    void SetupCurrentTask(){
        //Create the task texts in top left corner
        foreach (TextMeshProUGUI taskText in taskTexts)
        {
            Destroy(taskText.gameObject);
        }
        taskTexts.Clear();
        tasks[currentTaskIndex].SetupTask();
        Debug.Log(tasks[currentTaskIndex].GetTaskList.Count);
        for (int i = 0; i < tasks[currentTaskIndex].GetTaskList.Count; i++){
            SubTask task = tasks[currentTaskIndex].GetTaskList[i];
            GameObject taskTextObject = Instantiate(TaskText);
            taskTextObject.transform.SetParent(canvas.transform, false);
            taskTextObject.transform.Translate(0, -i * 30, 0);
            TextMeshProUGUI taskText = taskTextObject.GetComponent<TextMeshProUGUI>();
            taskText.text = task.ToString();
            taskTexts.Add(taskText);
        }
    }
}
