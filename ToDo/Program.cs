using System.ComponentModel.Design;
using ToDo.Models;

var service = new TodoService();

while (true)
{
    ShowMenu();
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("Add a Task:");
            var title = Console.ReadLine();
            if ( title != null)
            {
                service.Add(title);
            }
            break;

        case "2":
            ShowTodos();
            break;

        case "3":
            HandleStatus(service.MarkDone, "Enter Id to mark done: ");
            break;

        case "4":
            HandleStatus(service.Delete, "Enter Id to delete task: ");
            break;

        case "5":
        Console.WriteLine("Enter Id to update task: ");
        if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("New Title: ");
                var newTitle = Console.ReadLine();
                if (newTitle != null)
                {
                    service.Update(id, newTitle);
                }
            }
            break;

        case "6":
            return;
    }
}


void ShowMenu()
{
    Console.WriteLine("\n1. Add Task");
    Console.WriteLine("2. Show Todo List");
    Console.WriteLine("3. Mark Done");
    Console.WriteLine("4. Delete Task");
    Console.WriteLine("5. Update Task");
    Console.WriteLine("6. Exit");
}

void ShowTodos()
{
    foreach ( var t in service.GetAll())
    {
        Console.WriteLine($"{t.Id}. {t.Title} [{(t.IsDone ? "Done" : "Not Done ")}]");
    }
}

void HandleStatus(Func<int, bool> action, string message)
{
    Console.WriteLine(message);
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        bool result = action(id);

        if (!result)
        Console.WriteLine("Todo Not found.");
    }
}

