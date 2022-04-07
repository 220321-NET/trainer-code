using Microsoft.Data.SqlClient;
using System.Data;

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

    /// <summary>
    /// Updates Title, Content, Score, and IsClosed of Issue
    /// </summary>
    /// <param name="issueToUpdate">Issue object to update</param>
    public void UpdateIssue(Issue issueToUpdate)
    {
        DataSet questionSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Issues WHERE Id = @id", connection);
        cmd.Parameters.AddWithValue("@id", issueToUpdate.Id);

        SqlDataAdapter questionAdapter = new SqlDataAdapter(cmd);

        questionAdapter.Fill(questionSet, "IssueTable");

        DataTable? issueTable = questionSet.Tables["IssueTable"];
        if(issueTable != null && issueTable.Rows.Count > 0) {
            DataColumn[] dt = new DataColumn[1];
            dt[0] = issueTable.Columns["Id"];
            issueTable.PrimaryKey = dt;
            DataRow? rowToUpdate = issueTable.Rows.Find(issueToUpdate.Id);
            if(rowToUpdate != null) 
            {
                rowToUpdate["Title"] = issueToUpdate.Title;
                rowToUpdate["Content"] = issueToUpdate.Content;
                rowToUpdate["Score"] = issueToUpdate.Score;
                rowToUpdate["IsClosed"] = issueToUpdate.IsClosed;
            }

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(questionAdapter);
            SqlCommand updateCmd = commandBuilder.GetUpdateCommand();

            questionAdapter.UpdateCommand = updateCmd;
            questionAdapter.Update(issueTable);
        }
    }

    public void AddAnswer(Answer answerToAdd)
    {
        //DataSet, DataAdapter
        DataSet answerSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT Content, IssueId FROM Answers WHERE Id = -1", connection);

        SqlDataAdapter answerAdapter = new SqlDataAdapter(cmd);

        answerAdapter.Fill(answerSet, "AnswerTable");

        DataTable? answerTable = answerSet.Tables["AnswerTable"];
        if(answerTable != null) {
            DataRow newRow = answerTable.NewRow();
            newRow["Content"] = answerToAdd.Content;
            newRow["IssueId"] = answerToAdd.IssueId;

            answerTable.Rows.Add(newRow);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(answerAdapter);
            SqlCommand insertCmd = commandBuilder.GetInsertCommand();

            answerAdapter.InsertCommand = insertCmd;

            answerAdapter.Update(answerTable);
        }
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

        connection.Close();
        
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

    /// <summary>
    /// Gets all records from Issues table with Answers associated to the issue
    /// </summary>
    /// <returns>The list of issue with answers, an empty list if there is none</returns>
    public List<Issue> GetIssuesWithAnswers()
    {
        return new List<Issue>();
    }

    /// <summary>
    /// Looks for an issue record by its id
    /// </summary>
    /// <param name="id">Id of the Issue</param>
    /// <returns>The found issue, if not null</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Issue? GetIssueById(int id)
    {
        /** We'll implement this using Disconnected Architecture
        * DataAdapter is a class in ADO.NET that abstracts away connection management and makes it easier to do CRUD operations 
        * DataAdapter works with DataSet, which essentially is a bucket for the data
        * In DataSet, we have multiple DataTables which is a table of the result set from the initial query
        * Additionally, the dataset/dataTable has the name of the columns, so we can refer to columns by its name
        * Also it can add/update/delete rows without us having to hardcode and execute individual sql statements.
        */

        if(id < 1) throw new ArgumentOutOfRangeException("Id must be greater than 0");
        
        DataSet questionSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("Select Issues.Id as IssueId, Title, Issues.DateCreated as IssueDate, Issues.Content as IssueContent, IsClosed, Issues.Score as IssueScore, Answers.Id as AnswerId, Answers.DateCreated as AnswerDate, Answers.Score as AnswerScore, Answers.Content as AnswerContent, IsBestAnswer From Issues LEFT JOIN Answers ON Issues.Id = Answers.IssueId WHERE Issues.Id = @id", connection);
        cmd.Parameters.AddWithValue("@id", id);

        SqlDataAdapter questionAdapter = new SqlDataAdapter(cmd);

        questionAdapter.Fill(questionSet, "IssueTable");
        DataTable? issueTable = questionSet.Tables["IssueTable"];
        if(issueTable != null && issueTable.Rows.Count > 0)
        {
            Issue issue = new Issue();
            foreach(DataRow row in issueTable.Rows)
            {
                if(issue.Id == 0)
                {
                    issue.Id = (int) row["IssueId"];
                    issue.Title = (string) row["Title"];
                    issue.Content = (string) row["IssueContent"];
                    issue.Score = (int) row["IssueScore"];
                    issue.DateCreated = (DateTime) row["IssueDate"];
                    issue.IsClosed = (bool) row["IsClosed"];
                }

                Answer ans = new Answer{
                    Id = (int) row["AnswerId"],
                    Content = (string) row["AnswerContent"],
                    Score = (int) row["AnswerScore"],
                    DateCreated = (DateTime) row["AnswerDate"],
                    IsAccepted = (bool) row["IsBestAnswer"]
                };

                issue.Answers.Add(ans);
            }
            return issue;
        }
        return null;
    }

    public List<Issue> SearchIssue(string searchStr)
    {
        List<Issue> issues = new List<Issue>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("SELECT * FROM Issues where Title LIKE '%@str%' OR Content LIKE '%@str%';", connection);

        cmd.Parameters.AddWithValue("@str", searchStr);

        using SqlDataReader reader = cmd.ExecuteReader();

        if(reader.HasRows)
        {
            //Then, we found questions that contains particular search string
            //do something that data
            Issue issue = new Issue{
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                DateCreated = reader.GetDateTime(2),
                Content = reader.GetString(3),
                IsClosed = reader.GetBoolean(4),
                Score = reader.GetInt32(5)
            };
            issues.Add(issue);
        }
        return issues;
    }
}