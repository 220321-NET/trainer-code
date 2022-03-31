using Microsoft.Data.SqlClient;

namespace DL;

/**
* ADO.NET: is a collection of libraries that helps developers write data access code in a uniform fashion regardless of what data source they are dealing with
* All you need to be able to work with diff data source is a driver that is suited for a particular data source. For example, for SQL Server, we need Microsoft.Data.SqlClient. Install that to DL by navigating to DL folder and running dotnet add package Microsoft.Data.SqlClient.
* Two architecture styles: Connected and Disconnected
* Connected Architecture: We use objects such as DBConnection, DBCommand, DataReader to access data while we're connected to the database. DataReader is much faster at reading large amount of data compared to Disconnected Architecture.
* Disconnected Architecture: We use objects such as Data Adapter and DataSet (is like a bucket for the data) to have access to the data even when we're not connected to the db. The advantage of using DataAdapter, is that we have access to the schema of result set, so we can refer to the column by their name, instead of accessing by index.
*/
public class DBRepository : IRepository
{
    private readonly string _connectionString;

    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public void AddAnswer(Issue issueToUpdate)
    {
        throw new NotImplementedException();
    }

    public Issue CreateIssue(Issue issueToCreate)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("INSERT INTO Issues(Title, Content, DateCreated) OUTPUT INSERTED.Id VALUES (@title, @content, @date)", connection);

        cmd.Parameters.AddWithValue("@title", issueToCreate.Title);
        cmd.Parameters.AddWithValue("@content", issueToCreate.Content);
        cmd.Parameters.AddWithValue("@date", issueToCreate.DateCreated);

        // Risky code, SQL Injection
        // using SqlCommand cmd2 = new SqlCommand($"INSERT INTO Issues(Title, Content, DateCreated) VALUES ({issueToCreate.Title}, {issueToCreate.Content}, {issueToCreate.DateCreated})", connection);
        try
        {
            issueToCreate.Id = (int) cmd.ExecuteScalar();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        return issueToCreate;
    }

    /// <summary>
    /// Returns a list of all questions in Issues Table
    /// </summary>
    /// <returns>List of Issues, if none, empty list</returns>
    public List<Issue> GetAllIssues()
    {
        List<Issue> allQuestions = new List<Issue>();

        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("SELECT * FROM Issues", connection);
        using SqlDataReader reader = cmd.ExecuteReader();

        //This returns true if there are more rows to read, if not false
        //This also advances the datareader to the next row
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string title = reader.GetString(1);
            DateTime dateCreated = reader.GetDateTime(2);
            string content = reader.GetString(3);
            Boolean isClosed = reader.GetBoolean(4);
            int score = reader.GetInt32(5);

            Issue question = new Issue{
                Id = id,
                Title = title,
                DateCreated = dateCreated,
                Content = content,
                IsClosed = isClosed,
                Score = score
            };
            allQuestions.Add(question);
        }

        reader.Close();
        connection.Close();

        return allQuestions;
    }
}