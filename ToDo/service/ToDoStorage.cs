using Microsoft.Data.SqlClient;
using ToDo.Models;

public class FileStorage
{
    private readonly string connectionString = "DataSource=localhost,1434;Database=TodoApp;User ID=SA;Password=Millie0622;Pooling=False;Encrypt=False;Trust Server Certificate=True;Authentication=SqlPassword";
    public List<Todo> Load()
    {
        List<Todo> todos = new();
        using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        string query = "SELECT * FROM Todos";

        SqlCommand command = new SqlCommand(query, connection);

        using SqlDataReader reader = command.ExecuteReader();

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

    public void Save(Todo todo)
    {
        using SqlConnection connection =
            new SqlConnection(connectionString);

        connection.Open();

        string query = 
            @"INSERT OMTP Todos (Title, IsDone, VALUES (@title, @isDone))";
        
        SqlCommand command = 
            new SqlCommand(query, connection);
        
        command.Parameters.AddWithValue("@title", todo.Title);
        command.Parameters.AddWithValue("@isDone", todo.IsDone);


        command.ExecuteNonQuery();
    }
}
