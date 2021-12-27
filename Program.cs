using ExampleServer.Data;

TaskModel firstTask = new TaskModel("This is my first task.");
TaskModel secondTask = new("This is my second task.");

Console.WriteLine($"First task id: {firstTask.Id}.");
Console.WriteLine($"Second task id: {secondTask.Id}.");
