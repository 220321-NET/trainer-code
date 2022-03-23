using Models;
using System.ComponentModel.DataAnnotations;
using BL;

namespace UI;

public class MainMenu
{
    public void Start()
    {
        bool exit = false;
        do
        {
            Console.WriteLine("Welcome to StackLite");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("[1] Submit a question");
            Console.WriteLine("[2] View all questions");
            Console.WriteLine("[x] Exit");

            string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    //take in information about the new question
                    CreateNewIssue();
                break;

                case "2":
                    //get all questions and display them
                    DisplayAllIssues();
                break;

                case "x":
                    Console.WriteLine("Goodbye!");
                    exit = true;
                break;

                default:
                    Console.WriteLine("Invalid input, try again");
                break;
            }

        }while(!exit);
    }

    private void CreateNewIssue()
    {
        EnterIssueData:
        Console.WriteLine("Creating New Question");
        Console.WriteLine("Enter Title of the question: ");
        string? title = Console.ReadLine();

        Console.WriteLine("Enter Content: ");
        string? content = Console.ReadLine();

        Issue issueToCreate = new Issue();
        try
        {
            issueToCreate.Title = title!;
            issueToCreate.Content = content!;
        }
        catch(ValidationException ex)
        {
            Console.WriteLine(ex.Message);
            goto EnterIssueData;
        }

        new SLBL().CreateIssue(issueToCreate);
    }

    private void DisplayAllIssues()
    {
        Console.WriteLine("Here are all the questions");
        List<Issue> allIssues = new SLBL().GetIssues();

        foreach(Issue issueToDisplay in allIssues)
        {
            Console.WriteLine($"Title: {issueToDisplay.Title}, Content: {issueToDisplay.Content}, DateCreated: {issueToDisplay.DateCreated}, Score: {issueToDisplay.Score}");
        }
    }
}