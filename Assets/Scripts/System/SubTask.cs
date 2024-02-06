using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTask{
    public SubTask(string description, int subTaskCount = 1)
    {
        this.description = description;
        this.subTaskCount = subTaskCount;
        this.completedSubTaskCount = 0;
    }
    /// <summary>
    /// Description of the subtask
    /// </summary>
    public string description { get; private set;}
    /// <summary>
    /// Whether or not the subtask is completed
    /// </summary>
    public bool isCompleted => completedSubTaskCount == subTaskCount;
    /// <summary>
    /// The number of subtasks that need to be completed, -1 if the subtask is a single task
    /// </summary>
    public int subTaskCount { get; private set;}
    /// <summary>
    /// The number of subtasks that have been completed, -1 if the subtask is a single task (use isCompleted!)
    /// </summary>
    public int completedSubTaskCount { get; set;}
    public override string ToString()
    {
        if (subTaskCount == 1) return description;
        return description + " (" + completedSubTaskCount + "/" + subTaskCount + ")";
    }
}