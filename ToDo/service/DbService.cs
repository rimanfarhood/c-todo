using Microsoft.Data.SqlClient;
using ToDo.Models;

public class DatabaseService
{
    private string connectionString =
    "Data Source=localhost,1434;Database=TodoApp;User ID=SA;Password=Millie0622;Pooling=False;Encrypt=False;Trust Server Certificate=True;Authentication=SqlPassword";
    public void AddTodo(string title, DateTime? dueDate)
    {
        using SqlConnection connection =
            new SqlConnection(connectionString);

        connection.Open();
        

        string query =
            @"INSERT INTO dbo.Todos (Title, IsDone, DueDate)
          VALUES (@title, 0, @dueDate)";

        SqlCommand command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@title", title);

        if (dueDate == null)
        {
            command.Parameters.AddWithValue(
                "@dueDate",
                DBNull.Value
            );
        }
        else
        {
            command.Parameters.AddWithValue(
                "@dueDate",
                dueDate
            );
        }

        command.ExecuteNonQuery();
    }

    public List<Todo> LoadTodos()
    {
        List<Todo> todos = new();

        using SqlConnection connection =
            new SqlConnection(connectionString);

        connection.Open();

        string query = "SELECT * FROM dbo.Todos";

        SqlCommand command =
            new SqlCommand(query, connection);

        using SqlDataReader reader =
            command.ExecuteReader();

        while (reader.Read())
        {
            Todo todo = new Todo(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.IsDBNull(2)
                    ? null
                    : reader.GetDateTime(2)
            );

            if (reader.GetBoolean(3))
            {
                todo.MarkDone();
            }

            todos.Add(todo);
        }

        return todos;
    }

    public void Delete(int id)
    {
        using SqlConnection connection =
        new SqlConnection(connectionString);


        connection.Open();

        string query =
            "DELETE FROM dbo.Todos WHERE Id = @id";

        SqlCommand command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@id",
            id
        );

        command.ExecuteNonQuery();


    }

    public void Update(int id, string newTitle)
    {
        using SqlConnection connection =
        new SqlConnection(connectionString);


        connection.Open();

        string query =
            @"UPDATE dbo.Todos
      SET Title = @title
      WHERE Id = @id";

        SqlCommand command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@title",
            newTitle
        );

        command.Parameters.AddWithValue(
            "@id",
            id
        );

        command.ExecuteNonQuery();


    }

    public void MarkDone(Todo todo)
    {
        using SqlConnection connection =
        new SqlConnection(connectionString);


        connection.Open();

        string query =
            @"UPDATE dbo.Todos
      SET IsDone = @isDone
      WHERE Id = @id";

        SqlCommand command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@isDone",
            todo.IsDone
        );

        command.Parameters.AddWithValue(
            "@id",
            todo.Id
        );

        command.ExecuteNonQuery();


    }

}


// public void UpdateTodo(Todo todo)
// {
//     using SqlConnection connection =
//         new SqlConnection(connectionString);

//     connection.Open();
//     Console.WriteLine(connection.Database);
//     Console.WriteLine(connection.DataSource);

//     string query =
//         @"UPDATE dbo.Todos
//           SET IsDone = @isDone
//           WHERE Id = @id";

//     SqlCommand command =
//         new SqlCommand(query, connection);

//     command.Parameters.AddWithValue(
//         "@isDone",
//         todo.IsDone
//     );

//     command.Parameters.AddWithValue(
//         "@id",
//         todo.Id
//     );

//     command.ExecuteNonQuery();
// }


// }






// using SqlConnection connection =
//     new SqlConnection(connectionString);

// connection.Open();

// string query =
//     "INSERT INTO Todos (Title, IsDone, dueDate) VALUES (@title, 0, @dueDate)";

// SqlCommand command =
//     new SqlCommand(query, connection);

// command.Parameters.AddWithValue("@title", title);

// if (dueDate == null)
// {
//     command.Parameters.AddWithValue(
//         "@dueDate",
//         DBNull.Value
//     );
// }
// else
// {
//     command.Parameters.AddWithValue(
//         "@dueDate",
//         dueDate
//     );
// }


// command.ExecuteNonQuery();