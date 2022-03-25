using System.Text.Json;
namespace DL;

//Repository is a design pattern that abstract away the
//implementation details of  data access
//This means that the users of the respository can simply call
//Create, Read, Update, and Delete methods and more
//Without worrying about the actual details of data access
//nor even caring about how the data is actually stored
public class FileRepository
{
    private readonly string filePath ="../DL/StackLite.json";

    public List<Issue> GetAllIssues()
    {
        string jsonString;

        List<Issue> issues = new List<Issue>();
        try
        {
            issues = JsonSerializer.Deserialisze<List<Issue>>(jsonString) ?? new List<Issue>();
        }
        catch(Exception ex)
        {
            Console.WriteLine("There was an issue with the format of jsonString");
            Console.WriteLine(ex.Message);
        }
        

        return issues;
    }

    public void CreateIssue(Issue issueToCreate)
    {
        /*
        1. I want to make sure I have a thing to add
        2. I want to grab all questions from my list of questions
            2a. Reading from file and Deserializing
        3. I want to add my new question to the end of my list of questions
        4. I want to write that back into my file
            4a. Serializing List<Isuse> to string and writing to file
        */

        if(issueToCreate == null)
        {
            throw new ArgumentNullException();
        }
        
        List<Issue> allIssues = GetAllIssues();
        allIssues.Add(issueToCreate);

        string jsonString = JsonSerializer.Serialize(allIssues);
        File.WriteAllText(jsonString);
    }

}