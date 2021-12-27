namespace ExampleServer.Data;

// Repositories are used to hold and manage data using CRUD methods (Create, Read, Update, Delete)
class TaskRepository
{
    private readonly List<TaskModel> _taskList = new(); // concise and same as "new List<TaskModel>();"

    // Create (Add)
    public void AddTask(TaskModel task)
    {
        _taskList.Add(task);
    }

    // Read (Read/Get)
    public List<TaskModel> GetTasks()
    {
        return _taskList;
    }

    // Update (Update/Put)

    // Delete (Delete/Remove)
    public void DeleteTasksById(int id)
    {
        foreach (TaskModel task in _taskList)
        {
            if (task.Id == id)
            {
                _taskList.Remove(task);
                return;
            }
        }
    }
}