using System.Collections.Generic;

public interface ITaskManager
{
    void AddTask(string description);
    void RemoveTask(int id);
    void CompleteTask(int id);
    List<Task> GetAllTasks();
    List<Task> GetPendingTasks();
    List<Task> GetCompletedTasks();
}
