using Models;
using System.ComponentModel.DataAnnotations;
using BL;
using DL;

namespace UI;

public class MainMenu
{

    private readonly ISLBL _bl;

    //Dependency injection
    public MainMenu(ISLBL bl)
    {
        _bl = bl;
    }
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
            Console.WriteLine("[4] Delete an Issue");
            Console.WriteLine("[5] View answers");
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
                    //search for any specific issues
                    SearchIssues();
                break;

                case "4":
                    DeleteIssue();
                break;
                
                case "5":
                    viewAnswers();
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
        Issue createdIssue = _bl.CreateIssue(issueToCreate);
        if(createdIssue != null)
        {
            Console.WriteLine("Question added successfully!");
            Console.WriteLine(createdIssue);
        }
    }

    private void DisplayAllIssues()
    {
        Console.WriteLine("Here are all the questions");
        //asking BL to get all issues for us. UI doesn't care where or how it's getting it. An example of Abstraction
        List<Issue> allIssues = _bl.GetIssues();

        //Looping through the list we received to display all issues
        foreach(Issue issueToDisplay in allIssues)
        {
            Console.WriteLine(issueToDisplay);
        }
    }

    private Issue? SelectIssue()
    {
        Console.WriteLine("Select an Issue");

        List<Issue> allIssues = _bl.GetIssues();

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
            Console.WriteLine("Would you like to close this issue to any further questions? [Y/N]");

            string? response = Console.ReadLine().Trim().ToUpper();

            if(response == "Y" && allIssues[selection].IsClosed == true) 
            {
                Console.WriteLine("This issue has already been closed.");
            } 
            else if(response == "Y") 
            {
                allIssues[selection].IsClosed = true;
                Console.WriteLine("This issue has been closed to any further answers!");
            }
            
            return allIssues[selection];
        }
        else
        {
            Console.WriteLine("Please enter valid input");
            goto selectIssue;
        }
    }

    private void DeleteIssue()
    {
        Issue? x = SelectIssue();

        Delete:
        Console.WriteLine($"Are you sure you would like to delete: {x.Title}");
        Console.WriteLine("Y/N: ");
        string? response = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(response))
            goto Delete;

        char responseChar = response.Trim().ToUpper()[0];

        if(responseChar == 'N')
        {
            return;
        }
        else if(responseChar != 'Y')
        {
            Console.WriteLine("Please enter valid response");
            goto Delete;
        }
        

        _bl.DeletedIssue(x);
    }

    private void SearchIssues()
    {
        Console.WriteLine("Enter keywords to search questions for");
        string input = Console.ReadLine()!.ToLower();

        List<Issue> allIssues = _bl.GetIssues();
        /*
        This is an example of using a delegate with lambda expression. We can use delegates to pass in functions as parameters. Predicate, which we are using here, is a special type of delegate where we take in one argument (issue in our case), and return a boolean value. In this lambda expression, we are taking each of the issue in allIssues collection one by one, comparing whether its Title or Content contains our searchString, and returning true if it does, false if it doesn't. FindAll adds the object that the predicate returned true to the list it returns. It is a way to filter the list based on a custom condition.
        */
        List<Issue> foundIssues = allIssues.FindAll(issue => issue.Title.ToLower().Contains(input) || issue.Content.Contains(input));
        
        for (int i = 0; i < foundIssues.Count; i++)
        {
            Console.WriteLine("Issue Number " + (i + 1) + ":");
            Console.WriteLine(foundIssues[i]);

            AnswerQuestion:
            Console.WriteLine("Do you want to answer question #" +  (i + 1) + "? [Y/N]");
            string? answerUInput = Console.ReadLine().ToUpper();
            
            switch(answerUInput)
            {
                case "Y":  
                    Console.WriteLine("Add your answer below: ");
                    foundIssues[i].Answers.Add(new Answer());
                    foundIssues[i].Answers[foundIssues[i].Answers.Count - 1].Content = Console.ReadLine();
                    _bl.AddAnswer(foundIssues[i]);
                    foundIssues[i].GetAnswers();
                    break;
                case "N": 
                    break;
                default: 
                    Console.WriteLine("Invalid response. Please try again"); 
                    goto AnswerQuestion;
            }
        }
        return;
    }
    public void viewAnswers(){
        Console.WriteLine("Here are all the answers");
        //asking BL to get all issues for us. UI doesn't care where or how it's getting it. An example of Abstraction
        List<Issue> allIssues = _bl.GetIssues();

        //Looping through the list we received to display all issues
        foreach(Issue issueToDisplay in allIssues)
        {
            Console.WriteLine(issueToDisplay);
        }
    }
}
