using System;
using System.Collections.Generic;

public class TaskManager : ITaskManager
{
    private List<Task> tasks = new List<Task>();
    private int nextId = 1;
    private readonly object lockObj = new object();

    public void AddTask(string description)
    {
        lock (lockObj)
        {
            tasks.Add(new Task(nextId++, description));
        }
    }

    public void RemoveTask(int id)
    {
        lock (lockObj)
        {
            tasks.RemoveAll(task => task.Id == id);
        }
    }

    public void CompleteTask(int id)
    {
        lock (lockObj)
        {
            Task task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
        }
    }

    public List<Task> GetAllTasks()
    {
        lock (lockObj)
        {
           
            return new List<Task>(tasks);
        }
    }

    public List<Task> GetPendingTasks()
    {
        lock (lockObj)
        {
            return tasks.FindAll(task => !task.IsCompleted);
        }
    }

    public List<Task> GetCompletedTasks()
    {
        lock (lockObj)
        {
            return tasks.FindAll(task => task.IsCompleted);
        }
    }
}
