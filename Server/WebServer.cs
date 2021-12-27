using System.Net; // Using statement for line 9 to have access to HTTPS 
using System.Text.Json; 
using ExampleServer.Data; 

namespace ExampleServer.Server;

class WebServer
{
    private readonly TaskRepository _taskRepository; 

    private readonly HttpListener _httpListener = new();

    // Creating our WebServer constructor (our setup)
    public WebServer(string url, TaskRepository repository)
    {
        // The repository parameter is assigned to the readonly field
        _taskRepository = repository;

        // HTTP uses prefixes to check for valid access to and build our url
        _httpListener.Prefixes.Add(url);
    }

    // Creating the Run (Starting, Process, Stopping) functionality of our Server
    public void Run()
    {
        // Start the server
        _httpListener.Start();

        // Add a "debug" line that will write to the console our url address as a positive confirmation of Run() working
        Console.WriteLine($"Listening for connections on {_httpListener.Prefixes.First()}");

        // Handle our incoming connections/requests
        // The bulk of our logic, invoking the logic created via line 38 - 
        HandleIncomingConnections();

        // Stop the server
        _httpListener.Close();
    }

    // 
    private void HandleIncomingConnections()
    {
        // Have the server sit and wait for a connection 
        // Once a request comes in, it will create a context
        HttpListenerContext context = _httpListener.GetContext();

        // Get the Request and Response Objects (references) from the connection context
        // These are two objects that already exist, we are just accessing them
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        // Log the request in teh console, showing the "GET localhost:xxx"
        Console.WriteLine($"\n{request.HttpMethod} {request.Url}");
    }

    // Creating a method to send and use the response in tandem with the browser, building the connection from the ground up
    private void SendResponse(HttpListenerResponse response, HttpStatusCode statusCode, object? data)
    {
        // Convert our C# to JSON (can't send C# to the browser thus we convert to JSON that can be sent)
        string json = JsonSerializer.Serialize(data);
        response.ContentType = "Application/json";

        // Creating an array container for our data to satisfy the browser requirements
        byte[] buffer = Encoding.UTF8.GetBytes(json);
        response.ContentLength64 = buffer.Length;

        // Casting from one type to another
        response.StatusCode = (int)statusCode;

        // Now we need to write to the output stream
        response.OutputStream.Write(buffer, 0, buffer.Length);
        response.Close();
    }
}
