using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using ToDo.Models;

public class TodoService
{
private readonly DatabaseService database = new();

public void Add(string title, DateTime? dueDate = null)
{
    if (string.IsNullOrWhiteSpace(title))
        return;

    database.AddTodo(title, dueDate);
}

public List<Todo> GetAll()
{
    return database.LoadTodos();
}

public Todo? FindById(int id)
{
    return database.LoadTodos()
        .FirstOrDefault(t => t.Id == id);
}

public void MarkDone(int id)
{
    Todo? todo = FindById(id);

    if (todo == null)
        return;

    todo.MarkDone();

    database.MarkDone(todo);
}

public bool Delete(int id)
{
Todo? todo = FindById(id);

if (todo == null)
    return false;

database.Delete(id);

return true;

}

public bool Update(int id, string newTitle)
{
Todo? todo = FindById(id);

if (todo == null)
    return false;

database.Update(id, newTitle);

return true;

}

}




// public class TodoService
// {
//     private readonly DatabaseService database = new();

//     public TodoService()
//     {
        
//         database.AddTodo(title, dueDate);
//     }
//     public void Add(string title, DateTime? dueDate = null)
//     {
//         if (string.IsNullOrWhiteSpace(title)) return;
//         todos.Add(new Todo(nextId++, title, dueDate));
//         storage.Save(todos);
//     }
//     public List<Todo> GetAll() => todos;

//     public bool Delete(int id)
//     {
//         var todo = FindById(id);
//         if (todo == null) return false;

//         todos.Remove(todo);
//         storage.Save(todos);
//         return true;
//     }
//     public bool DeleteAll()
//     {
//         todos.Clear();
//         storage.Save(todos);
//         return true;
//     }
//     public bool Update(int id, string newTitle)
//     {
//         var todo = FindById(id);
//         if (todo == null) return false;

//         var result = todo.UpdateTitle(newTitle);
//         if (result) storage.Save(todos);
//         return result;
//     }

//     public bool MarkDone(int id)
//     {
//         try
//         {
//             var todo = FindById(id);
//             todo.MarkDone();
//             storage.Save(todos);
//             return true;
//         }

//         catch (InvalidOperationException)
//         {
//             return false;
//         }
//     }

//     private Todo FindById(int id)
//     {
//         return todos.First(t => t.Id == id);
//     }

// }
