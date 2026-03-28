using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using ToDo.Models;

public class TodoService
{
    private readonly List<Todo> todos = new();
    private int nextId = 1;

    public void Add(string title)
    {
        if (string.IsNullOrWhiteSpace(title)) return;
        todos.Add(new Todo(nextId++, title));
    }
    public List<Todo> GetAll() => todos;

    public bool Delete(int id)
    {
        var todo = FindById(id);
        if (todo == null) return false;

        todos.Remove(todo);
        return true;
    }

    public bool Update(int id, string newTitle)
    {
        var todo = FindById(id);
        if (todo == null) return false;

        return todo.UpdateTitle(newTitle);
    }
    public bool MarkDone(int id)
    {
        try
        {
            var todo = FindById(id);
            todo.MarkDone();
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
