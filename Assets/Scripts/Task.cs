using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task
{
    /// <summary>
    /// Spawn point where the task will spawn the player on start
    /// </summary>
    [SerializeField] GameObject SpawnPoint;
    /// <summary>
    /// List of subtasks that need to be completed
    /// </summary>
    List<SubTask> subTasks = new List<SubTask>();
    /// <summary>
    /// Whether or not the progression of the task has been updated since the last check
    /// </summary>
    bool wasUpdated = false; public bool WasUpdated => wasUpdated;
    /// <summary>
    /// Creates the subtasks
    /// </summary>
    abstract public void SetupTask();
    /// <summary>
    /// Returns the list of subtasks
    /// </summary>
    /// <returns>A list of subtasks</returns>
    abstract public List<SubTask> GetTaskList();
    /// <summary>
    /// Checks if the task is completed
    /// </summary>
    /// <returns>Whether all subtasks are completed</returns>
    public bool IsCompleted(){
        foreach (SubTask subTask in subTasks)
        {
            if (!subTask.isCompleted) return false;
        }
        return true;
    }
    /// <summary>
    /// Updates subtasks state
    /// </summary>
    abstract public void CheckTask();
}


