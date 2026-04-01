using System.Data.SqlTypes;
using System.Text.Json;
using ToDo.Models;

public class FileStorage
{
    private readonly string filePath = "todos.json";

    public List<Todo> Load()
    {
        if (!File.Exists(filePath))
            return new List<Todo>();
        
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Todo>>(json) ?? new List<Todo>();
    }

    public void Save(List<Todo> todos)
    {
        var json = JsonSerializer.Serialize(todos, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, json);
    }
}