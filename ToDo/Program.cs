using System.Reflection;
using System.Security;
using ToDo.Models;

var service = new TodoService();
ShowMenu();

while (true)
{

    var choice = Console.ReadLine();
    if (choice !=  "6")
    {
        Console.WriteLine("\nPress M to show menu\n");
    }
    if (choice?.ToLower() == "m")
    {
        ShowMenu();
        continue;
    }
    switch (choice)
    {
        case "1":
            Console.WriteLine("Add a Task:\n");
            while (true)
            {
                var title = Console.ReadLine();

                if (title?.ToLower() == "m")
                {
                    ShowMenu();
                    break;
                }
                if (title != null && !string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("\nEnter due date (yyyy-MM-dd) (optional, press Enter to skip)");
                    var input = Console.ReadLine();
                    DateTime? dueDate = null;

                    if (!string.IsNullOrWhiteSpace(input)
                    && DateTime.TryParse(input, out var parsed))
                    {
                        dueDate = parsed;
                    }
                    service.Add(title, dueDate);
                    Console.WriteLine("Task added! Add another task or type 'm' to go back to menu:");
                }
            }
            break;

        case "2":
            if (!service.GetAll().Any())
            {
                Console.WriteLine("You Have no Tasks Yet.\n");
                ShowMenu();
            }
            else
            {
                ShowTodos();
                Console.WriteLine("Type 'm' to go back to the menu");
            }
            break;

        case "3":
            HandleStatus(service.MarkDone, "Enter Id to mark done: ");
            ShowTodos();
            ShowMenu();
            break;

        case "4":
            Console.WriteLine("Enter Id to delete task or type 'all' to delete all tasks: ");
            var deleteInput = Console.ReadLine();
            if (deleteInput?.Trim().ToLower() == "all")
            {
                service.DeleteAll();
                Console.WriteLine("\nAll tasks are deleted");
                ShowMenu();
            }
            else if (int.TryParse(deleteInput, out int deleteId))
            {
                if (!service.Delete(deleteId))
                    Console.WriteLine("Todo Not found.");
            }
            else
            {
                Console.WriteLine("Invalid input. Type a task id or 'all'.");
            }
            ShowTodos();
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
            ShowTodos();
            break;

        case "6":
            return;
    }
}


void ShowMenu()
{
    Console.WriteLine("\n\t* Todo List * ");
    Console.WriteLine("\n(1) Add Task");
    Console.WriteLine("(2) Show Todo List");
    Console.WriteLine("(3) Mark Done");
    Console.WriteLine("(4) Delete Task");
    Console.WriteLine("(5) Update Task");
    Console.WriteLine("(6) Exit");
}

void ShowTodos()
{
    foreach (var t in service.GetAll())
    {
        Console.WriteLine($"({t.Id}) Due Date: {t.DueDate?.ToString("yyyy-mm-dd")}\n\t\t{t.Title} \t {(t.IsDone ? "✅" : "❌")} \n");
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

