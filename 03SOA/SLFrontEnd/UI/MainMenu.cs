using Models;
using System.ComponentModel.DataAnnotations;

namespace UI;

internal class MainMenu
{

    private readonly HttpService _httpService;

    //Dependency injection
    public MainMenu(HttpService httpService)
    {
        _httpService = httpService;
    }
    public async Task Start()
    {
        bool exit = false;
        do
        {
            Console.WriteLine("Welcome to StackLite");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("[1] Submit a question");
            Console.WriteLine("[2] View all questions");
            Console.WriteLine("[3] Answer a question");
            Console.WriteLine("[4] Delete an Issue");
            Console.WriteLine("[5] View answers");
            Console.WriteLine("[6] Close an issue");
            Console.WriteLine("[x] Exit");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    //take in information about the new question
                    CreateNewIssue();
                    break;

                case "2":
                    //get all questions and display them
                    await DisplayAllIssuesAsync();
                    break;

                case "3":
                    //search for any specific issues
                    AddAnswer();
                    break;

                case "4":
                    DeleteIssue();
                    break;

                case "5":
                    viewAnswers();
                    break;

                case "6":
                    CloseIssue();
                    break;

                case "x":
                    Console.WriteLine("Goodbye!");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid input, try again");
                    break;
            }

        } while (!exit);
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
        catch (ValidationException ex)
        {
            Console.WriteLine(ex.Message);
            goto EnterIssueData;
        }
        finally
        {
            //do stuff here, such as cleaning up the outside resources
        }

        //instantiating new SLBL class to ask it to create new issue and add it to our data storage
        // Issue createdIssue = _bl.CreateIssue(issueToCreate);
        // if (createdIssue != null)
        // {
        //     Console.WriteLine("Question added successfully!");
        //     Console.WriteLine(createdIssue);
        // }
    }

    private async Task DisplayAllIssuesAsync()
    {
        Console.WriteLine("Here are all the questions");
        List<Issue> allIssues = await _httpService.GetAllIssuesAsync();
        //asking BL to get all issues for us. UI doesn't care where or how it's getting it. An example of Abstraction
        // List<Issue> allIssues = _bl.GetIssues();

        //Looping through the list we received to display all issues
        foreach (Issue issueToDisplay in allIssues)
        {
            Console.WriteLine(issueToDisplay);
        }
    }

    private Issue? SelectIssue(List<Issue>? issues)
    {
        Console.WriteLine("Select an Issue");

        // issues = issues ?? _bl.GetIssues();

        //If there is no issues to display, then let the user know and return null
        if (issues.Count == 0)
        {
            Console.WriteLine("No Issues to display :/");
            return null;
        }

    //if there is, list out the issues with a number for users to select by
    selectIssue:
        for (int i = 0; i < issues.Count; i++)
        {
            Console.WriteLine($"[{i}] {issues[i]}");
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
        if (Int32.TryParse(Console.ReadLine(), out selection) && (selection >= 0 && selection < issues.Count))
        {
            return issues[selection];
        }
        else
        {
            Console.WriteLine("Please enter valid input");
            goto selectIssue;
        }
    }

    private void CloseIssue()
    {
        Issue? issueToClose = SelectIssue(SearchIssues());
        Console.WriteLine(issueToClose);
        Console.WriteLine("Would you like to close this issue to any further answers? [Y/N]");

        string? response = Console.ReadLine()?.Trim().ToUpper();

        if (response == "Y" && issueToClose?.IsClosed == true)
        {
            Console.WriteLine("This issue has already been closed.");
        }
        else if (response == "Y")
        {
            //Updating the question record
            // _bl.CloseIssue(issueToClose);
            Console.WriteLine("This issue has been closed to any further answers!");
        }
    }


    private void DeleteIssue()
    {
        Issue? issueToDelete = SelectIssue(SearchIssues());

    Delete:
        Console.WriteLine($"Are you sure you would like to delete: {issueToDelete.Title}");
        Console.WriteLine("Y/N: ");
        string? response = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(response))
            goto Delete;

        char responseChar = response.Trim().ToUpper()[0];

        if (responseChar == 'N')
        {
            return;
        }
        else if (responseChar != 'Y')
        {
            Console.WriteLine("Please enter valid response");
            goto Delete;
        }


        // _bl.DeletedIssue(issueToDelete);
    }

    private List<Issue> SearchIssues()
    {
        Console.WriteLine("Enter keywords to search questions for");
        string input = Console.ReadLine()!.ToLower();

        // return _bl.SearchIssue(input);
        return new List<Issue>();
    }

    private void AddAnswer()
    {
        Issue? selectedQ = SelectIssue(SearchIssues());
        if(selectedQ == null) 
        {
            Console.WriteLine("No question has been selected");
            return;
        }
        
        AnswerQuestion:
        Console.WriteLine("Do you want to answer this question? [Y/N]");
        string? answerUInput = Console.ReadLine()?.ToUpper();

        switch (answerUInput)
        {
            case "Y":
                Console.WriteLine("Add your answer below: ");
                Answer answerToAdd = new Answer {
                    IssueId = selectedQ.Id
                };
                try
                {
                    answerToAdd.Content = Console.ReadLine()!;
                }
                catch (ValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto AnswerQuestion;
                }
                //Creating new Record in answers table
                // _bl.AddAnswer(answerToAdd);
                selectedQ.Answers.Add(answerToAdd);
                selectedQ.GetAnswers();
                break;
            case "N":
                break;
            default:
                Console.WriteLine("Invalid response. Please try again");
                goto AnswerQuestion;
        }
    }
    public void viewAnswers()
    {
        Console.WriteLine("Here are all the answers");
        //asking BL to get all issues for us. UI doesn't care where or how it's getting it. An example of Abstraction
        List<Issue> allIssues = new List<Issue>(); 
        //_bl.GetIssues();

        //Looping through the list we received to display all issues
        foreach (Issue issueToDisplay in allIssues)
        {
            Console.WriteLine(issueToDisplay);
        }
    }
}