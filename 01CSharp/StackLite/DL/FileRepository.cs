using System.Text.Json;
using Models;

namespace DL;

//Repository is a design pattern that abstract away the 
//implementation details of data access
//This means, the users of repository can simply call
//Create, Read, Update, Delete methods and more
//without worrying about the actual details of data access
//nor even caring about how the data is actually stored
public class FileRepository
{
    private readonly string filePath = "../DL/StackLite.json";

    public List<Issue> GetAllIssues()
    {
        //We are first initializing a string variable to hold the result of the file read
        string jsonString = "";

        try
        {
            //and we are taking File class's ReadAllText method to read the content in the file path we have specified
            //There is a chance that it can throw an exception, so we wrap this in try/catch block.
            jsonString = File.ReadAllText(filePath);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            //this block gets executed regardless of whether we have caught an exception or not
        }

        List<Issue> issues = new List<Issue>();
        try
        {
            issues = JsonSerializer.Deserialize<List<Issue>>(jsonString) ?? new List<Issue>();
        }
        catch (JsonException ex)
        {
            Console.WriteLine("There was an issue with the format of jsonString");
            Console.WriteLine(ex.Message);
        }

        return issues;
    }

    public void CreateIssue(Issue issueToCreate)
    {
        /*
        * 1. I want to make sure I have a thing to add
        * 2. I want to grab all questions from my list of questions
        *   2a. Reading from the file and Deserializing
        * 3. I want to add my new question to the end of my list of questions
        * 4. I want to write that back into my file
        *   4a. Serializing List<Issue> to string and writing to the file.
        *
        */

        if(issueToCreate == null) throw new ArgumentNullException();

        List<Issue> allIssues = GetAllIssues();
        allIssues.Add(issueToCreate);

        string jsonString = JsonSerializer.Serialize(allIssues);
        File.WriteAllText(filePath, jsonString);
    }
}