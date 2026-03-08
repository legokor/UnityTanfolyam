using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    private static TaskController instance;
    public static TaskController Instance{
        get{
            if (instance == null){
                instance = FindFirstObjectByType<TaskController>();
            }
            return instance;
        }
    }
    void Awake(){
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }
    }



    [SerializeField] Canvas canvas;
    [SerializeField] GameObject TaskText;
    [SerializeField] int session;
    [SerializeField] List<Task> tasks = new List<Task>();
    List<TextMeshProUGUI> taskTexts = new List<TextMeshProUGUI>();
    int currentTaskIndex;
    public Task currentTask => tasks[currentTaskIndex];

    [SerializeField] private float padding = 10;
    [SerializeField] private float taskTextOffset = 30;

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
        if (currentTaskIndex >= tasks.Count){
            if (taskTexts.Count == 0) return;
            foreach(TextMeshProUGUI tt in taskTexts){
                Destroy(tt.gameObject);
            }
            taskTexts.Clear();
            GameObject taskTextObject = Instantiate(TaskText);
            taskTextObject.transform.SetParent(canvas.transform, false);
            TextMeshProUGUI taskText = taskTextObject.GetComponent<TextMeshProUGUI>();
            taskText.text = "Sikeresen teljesítetted az összes feladatot!";
            taskTexts.Add(taskText);
            return;
        }
        if (tasks[currentTaskIndex].WasUpdated)
        {
            for (int i = 0; i < taskTexts.Count; i++){
                if (i >= tasks[currentTaskIndex].GetTaskList.Count) break;
                taskTexts[i].text = tasks[currentTaskIndex].GetTaskList[i].ToString();
                taskTexts[i].fontStyle = tasks[currentTaskIndex].GetTaskList[i].isCompleted ? FontStyles.Strikethrough : FontStyles.Normal;
            }
        }
        if (tasks[currentTaskIndex].IsCompleted()){
            currentTaskIndex++;
            if (currentTaskIndex >= tasks.Count) return;
            SetupCurrentTask();
            UnityEngine.Debug.Log(Application.persistentDataPath + "/session.txt");
            string[] sessionStrings = File.ReadAllText(Application.persistentDataPath + "/session.txt").Split(";");
            UnityEngine.Debug.Log(Application.persistentDataPath + "/session.txt");
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
        if (currentTaskIndex >= tasks.Count) return;
        tasks[currentTaskIndex].SetupTask();
        for (int i = 0; i < tasks[currentTaskIndex].GetTaskList.Count; i++){
            SubTask task = tasks[currentTaskIndex].GetTaskList[i];
            GameObject taskTextObject = Instantiate(TaskText);

            // Set position of task text
            var rectt = taskTextObject.GetComponent<RectTransform>();
            rectt.SetParent(canvas.transform, false);   // Parent to canvas
            rectt.anchorMax = new Vector2(0, 1);        // Set position relative to upper left corner
            rectt.anchorMin = new Vector2(0, 1);        // Set position relative to upper left corner
            rectt.pivot = new Vector2(0, 1);            // Set the origin of the text to the upper left corner
            rectt.anchoredPosition = Vector2.zero;      // Set the actual position to zero
                                                        // (this will place the text in the upper left corner, because of the anchoring)
            rectt.Translate(0, -i * taskTextOffset, 0); // Translate the text down to prevent overlapping
            rectt.Translate(padding, -padding, 0);      // Add a bit of padding
            
            TextMeshProUGUI taskText = taskTextObject.GetComponent<TextMeshProUGUI>();
            taskText.text = task.ToString();
            taskTexts.Add(taskText);
        }
        PlayerController.Player.GoTo(tasks[currentTaskIndex].spawnPoint.position);
    }
}
