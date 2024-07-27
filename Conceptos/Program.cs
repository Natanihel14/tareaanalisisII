using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        DataStorage dataStorage = new DataStorage();
        ITaskManager taskManager = dataStorage.GetTaskManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Eliminar tarea");
            Console.WriteLine("3. Completar tarea");
            Console.WriteLine("4. Ver todas las tareas");
            Console.WriteLine("5. Ver las tareas pendientes");
            Console.WriteLine("6. Ver las tareas completadas");
            Console.WriteLine("7. Salir");
            Console.Write("Escoge una opcion: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Ingresa una descripcion para la tarea: ");
                    string description = Console.ReadLine();
                    new Thread(() => taskManager.AddTask(description)).Start();
                    break;
                case "2":
                    Console.Write("Ingresa ID de la tarea para removerla: ");
                    int idToRemove = int.Parse(Console.ReadLine());
                    new Thread(() => taskManager.RemoveTask(idToRemove)).Start();
                    break;
                case "3":
                    Console.Write("Ingresa ID de la tarea para completarla: ");
                    int idToComplete = int.Parse(Console.ReadLine());
                    new Thread(() => taskManager.CompleteTask(idToComplete)).Start();
                    break;
                case "4":
                    List<Task> allTasks = taskManager.GetAllTasks();
                    Console.WriteLine("Todas las tareas:");
                    allTasks.ForEach(task => Console.WriteLine($"{task.Id}: {task.Description} - Completed: {task.IsCompleted}"));
                    break;
                case "5":
                    List<Task> pendingTasks = taskManager.GetPendingTasks();
                    Console.WriteLine("Tareas pendientes:");
                    pendingTasks.ForEach(task => Console.WriteLine($"{task.Id}: {task.Description}"));
                    break;
                case "6":
                    List<Task> completedTasks = taskManager.GetCompletedTasks();
                    Console.WriteLine("Tareas completadas:");
                    completedTasks.ForEach(task => Console.WriteLine($"{task.Id}: {task.Description}"));
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Opcion invalida, intenta de nuevo.");
                    break;
            }
        }
    }
}
