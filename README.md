# To-Do Console App

**Simple console-based appliocation built in C#.** <br>
Built to practice C# 

----

## Features 
* Add Task (Single oir multiple)
* View All Tasks
* Mark Tasks as Completed
* Update Tasks
* Delete Task 
* Handle Empty Task 



## To Run
### Requirements 
* .NET SKD 10.0

    [Download .NET 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)

## Run locally 
git clone: https://github.com/rimanfarhood/c-todo.git <br>
To run the application use the command: **dotnet run**

## Usage
On the inital run the application displays a menu:
1. Add Task
2. Show Todo List
3. Mark Done
4. Delete Task
5. Update Task
6. Exit

Once You Choose an option the menu will disapare, To Go back to the menu you press M/m.

### Add Task
 Enter task one by one or multiple tasks. <br>
 Each task will get an number ID in transcending order.
 
 ### Show Tasks
 Displays your todo list. <br>
 If list is empty a message will be shown.

 ### Mark Task as Done
 To do mark done you enter the number ID.<br>
 Your updated list will be displayed.

 ### Delete Task
 Enter task ID to delete 

 ### Update Task
 Enter task ID to update and new task.

## Project Structure
Models/ - Data Model <br>
Services/ - Business Logic <br>
Program.cs - Console UI