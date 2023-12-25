
using hw1.Models;
namespace hw1.Services;
    


public static class TaskService
{
    private static List<Task1> myTasks;

    static TaskService()
    {
        myTasks = new List<Task1>
        {
            new Task1 { Id = 1, Name = "Regular", IsDone = false},
            new Task1 { Id = 2, Name = "Veggi", IsDone = false},
            new Task1 { Id = 3, Name = "Special", IsDone = true}
        };
    }

    public static List<Task1> GetAll() => myTasks;

    public static Task1 GetById(int id) 
    {
        return myTasks.FirstOrDefault(t => t.Id == id);
    }

    public static int Add(Task1 newTask)
    {
        if (myTasks.Count == 0)

            {
                newTask.Id = 1;
            }
            else
            {
        newTask.Id =  myTasks.Max(t => t.Id) + 1;

            }

        myTasks.Add(newTask);

        return newTask.Id;
    }
  
    public static bool Update(int id, Task1 newTask)
    {
        if (id != newTask.Id)
            return false;

        var existingTask = GetById(id);
        if (existingTask == null )
            return false;

        var index = myTasks.IndexOf(existingTask);
        if (index == -1 )
            return false;

        myTasks[index] = newTask;

        return true;
    }  

      
    public static bool Delete(int id)
    {
        var existingTask = GetById(id);
        if (existingTask == null )
            return false;

        var index = myTasks.IndexOf(existingTask);
        if (index == -1 )
            return false;

        myTasks.RemoveAt(index);
        return true;
    }  



}