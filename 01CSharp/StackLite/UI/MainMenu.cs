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
            Console.WriteLine("[3] Select an Issue");
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

                case "3":
                    SearchIssues();
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
            Console.WriteLine(issueToDisplay);
        }
    }

    private Issue? SelectIssue()
    {
        Console.WriteLine("Select an Issue");
        List<Issue> allIssues = new SLBL().GetIssues();

        if(allIssues.Count == 0) 
        {
            Console.WriteLine("No Issues to display :/");
            return null;
        }

        selectIssue:
        for(int i = 0; i < allIssues.Count; i++)
        {
            Console.WriteLine($"[{i}] {allIssues[i]}");
        }

        int selection;
        if(Int32.TryParse(Console.ReadLine(), out selection) && (selection >= 0 && selection < allIssues.Count))
        {
            Console.WriteLine(allIssues[selection]);
            return allIssues[selection];
        }
        else
        {
            Console.WriteLine("Please enter valid input");
            goto selectIssue;
        }
    }

    private List<Issue> SearchIssues()
    {
        Console.WriteLine("Enter keywords to search questions for");
        string input = Console.ReadLine()!.ToLower();

        List<Issue> allIssues = new SLBL().GetIssues();
        List<Issue> foundIssues = allIssues.FindAll(issue => issue.Title.ToLower().Contains(input) || issue.Content.Contains(input));

        foreach(Issue issue in foundIssues)
        {
            Console.WriteLine(issue);
        }
        return foundIssues;
    }
}