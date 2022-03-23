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

    //"helper method"
    private void CreateNewIssue()
    {
        //label, marks a spot in the code base that we can jump to later
        EnterIssueData:
        Console.WriteLine("Creating New Question");
        Console.WriteLine("Enter Title of the question: ");
        string? title = Console.ReadLine();

        Console.WriteLine("Enter Content: ");
        string? content = Console.ReadLine();

        Issue issueToCreate = new Issue();
        //Exception handling, try/catch/finally block.
        //wrap codes that could throw exception in try block
        //handle exceptions in catch blocks
        //There can be more than 1 catch blocks
        //finally block gets executed regardless of exception being thrown
        //It is a great place to do stuff that needs to happen regardless of whether the exception was thrown or not, such as cleaning up the resources
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
        finally
        {
            //do stuff here, such as cleaning up the outside resources
        }

        //instantiating new SLBL class to ask it to create new issue and add it to our data storage
        new SLBL().CreateIssue(issueToCreate);
    }

    private void DisplayAllIssues()
    {
        Console.WriteLine("Here are all the questions");
        //asking BL to get all issues for us. UI doesn't care where or how it's getting it. An example of Abstraction
        List<Issue> allIssues = new SLBL().GetIssues();

        //Looping through the list we received to display all issues
        foreach(Issue issueToDisplay in allIssues)
        {
            Console.WriteLine(issueToDisplay);
        }
    }

    private Issue? SelectIssue()
    {
        Console.WriteLine("Select an Issue");
        List<Issue> allIssues = new SLBL().GetIssues();

        //If there is no issues to display, then let the user know and return null
        if(allIssues.Count == 0) 
        {
            Console.WriteLine("No Issues to display :/");
            return null;
        }

        //if there is, list out the issues with a number for users to select by
        selectIssue:
        for(int i = 0; i < allIssues.Count; i++)
        {
            Console.WriteLine($"[{i}] {allIssues[i]}");
        }

        int selection;
        /*
        * TryParse is an example of a method that uses pass by reference parameter
        * out parameter takes in "outside variable" modifies it inside the method body
        * and the modification is reflected on variable outside of the method.
        * Normally C# is pass by value, as in the modification made inside of method body is not reflected outside of it. out param is great when you want to return more than one value, such as TryParse, where it's returning whether the parse was successful or not, and the result of parse in out param. 
        */
        /*
        * here we are also checking if the parse result lies within the bounds of our list, to make sure we are not going to get the index out of bound exception
        */
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
        /*
        This is an example of using a delegate with lambda expression. We can use delegates to pass in functions as parameters. Predicate, which we are using here, is a special type of delegate where we take in one argument (issue in our case), and return a boolean value. In this lambda expression, we are taking each of the issue in allIssues collection one by one, comparing whether its Title or Content contains our searchString, and returning true if it does, false if it doesn't. FindAll adds the object that the predicate returned true to the list it returns. It is a way to filter the list based on a custom condition.
        */
        List<Issue> foundIssues = allIssues.FindAll(issue => issue.Title.ToLower().Contains(input) || issue.Content.Contains(input));

        foreach(Issue issue in foundIssues)
        {
            Console.WriteLine(issue);
        }
        return foundIssues;
    }
}