using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using ToDo.Models;

public class TodoService
{
    private readonly FileStorage storage = new();
    private readonly List<Todo> todos = new();
    private int nextId = 1;

    public TodoService()
    {
        todos = storage.Load();
        if (todos.Any())
            nextId = todos.Max(t => t.Id) + 1;
    }
    public void Add(string title, DateTime? dueDate = null)
    {
        if (string.IsNullOrWhiteSpace(title)) return;
        todos.Add(new Todo(nextId++, title, dueDate));
        storage.Save(todos);
    }
    public List<Todo> GetAll() => todos;

    public bool Delete(int id)
    {
        var todo = FindById(id);
        if (todo == null) return false;

        todos.Remove(todo);
        storage.Save(todos);
        return true;
    }
    public bool DeleteAll()
    {
        todos.Clear();
        storage.Save(todos);
        return true;
    }
    public bool Update(int id, string newTitle)
    {
        var todo = FindById(id);
        if (todo == null) return false;

        var result = todo.UpdateTitle(newTitle);
        if (result) storage.Save(todos);
        return result;
    }

    public bool MarkDone(int id)
    {
        try
        {
            var todo = FindById(id);
            todo.MarkDone();
            storage.Save(todos);
            return true;
        }

        catch (InvalidOperationException)
        {
            return false;
        }
    }

    private Todo FindById(int id)
    {
        return todos.First(t => t.Id == id);
    }

}
