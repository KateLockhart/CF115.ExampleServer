namespace ExampleServer.Data;

class TaskModel
{
    private static int TotalTasks = 0;

    public TaskModel(string message)
    {
        Id = ++TotalTasks; // Id = 1, TotalTasks = 1; increments before it assigns the Id
        // Id = TotalTasks++; // Id = 0, TotalTasks = 1
        Message = message;
    }

    public int Id { get; } // Remove the set; as it will increment with logic above, cannot be assigned an Id outside of this class (no reading or writing to property)
    public string Message { get; set; }
}