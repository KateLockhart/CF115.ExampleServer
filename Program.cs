using ExampleServer.Data;
using ExampleServer.Server;

// Creating new instances of task to demo Id incrementing
TaskModel firstTask = new TaskModel("This is my first task.");
TaskModel secondTask = new("This is my second task.");

Console.WriteLine($"First task id: {firstTask.Id}.");
Console.WriteLine($"Second task id: {secondTask.Id}.");

TaskRepository repo = new();
repo.AddTask(firstTask);
repo.AddTask(secondTask);

// repo.DeleteTasksById(1); // Deletes task 1

List<TaskModel> tasks = repo.GetTasks(); // Creating a variable that is a snapshot of all our tasks via the GetTasks() Read method made in TaskRepository.cs
foreach(TaskModel task in tasks) // For each task in our List Collection of the variable name tasks created on line 16
{
    Console.WriteLine(task.Message); // Prints task message to the console
}

// Implimenting the WebServer (first add using statement to top of file) by adding a new instance of our constructor from WebServer.cs
WebServer webServer = new WebServer("http://localhost:8000/", repo);

// Calling our Run() functionality from WebServer.cs
webServer.Run();