//this is .NET 6 feature, file scoped namespace
namespace StackLite;

//class is part of "type"
//public is an access modifier, 
//which is how we control the access to types and type members
//Public, Private, Protected, and Internal
//Defaults are, Internal for types (such as class)
//and Private for type members such methods, fields, or properties
//There are other access modifiers (the combo ones) such as private protected
//and protected internal
public class StackLiteMenu
{
    // public string PropertyExample { get; set; }

    // public int Sum(int a, int b)
    // {
    //     return a + b;
    // }
    //method defines a behavior of a class
    public void MainMenu()
    {
        List<Issue> issues = new List<Issue>();
        // List<int> intList = new List<int>();
        // List<string> stringList = new List<string>();
        // List<bool> boolList = new List<bool>();
        // List<List<Issue>> listofListofIssues = new List<List<Issue>>();
        // listofListofIssues.Add(new List<Issue>() {
        //     new Issue("title", "content"),
        //     new Issue("another", "one"),
        //     new Issue("third", "one")
        // });
        // listofListofIssues.Add(new List<Issue>() {
        //     new Issue("2title", "2content"),
        //     new Issue("another", "one")
        // });
        Console.WriteLine("Welcome to StackLite!");
        bool exit = false;
        do
        {
            EnterTitle:
            Console.WriteLine("What brings you here today?");

            // string? input = Console.ReadLine();

            // if(input == null) {
            //     Console.WriteLine("you didn't type anything!");
            // }
            
            //null coalescing operator (??)
            string title = Console.ReadLine() ?? "";
            if(String.IsNullOrWhiteSpace(title)) {
                Console.WriteLine("Your title cannot be empty");
                goto EnterTitle;
            }
            
            //Some Examples of Value types in C#
            // int n = 10; // is Int32
            // //or true
            // bool boolean = false;
            // double number = 0.00;
            // float floatNum = 0.00f;
            // decimal decimalNumber = 0.00M;
            // long longNumber = 100000L; //Long is Int64
            // short shortNumber = new short();

            EnterBody:
            Console.WriteLine("Tell us more about your issue");
            string content = Console.ReadLine() ?? "";

            if(String.IsNullOrWhiteSpace(content)) {
                Console.WriteLine("You can't have your body be empty");
                goto EnterBody;
            }

            // Issue newIssue = new Issue();
            // newIssue.Title = title;
            // newIssue.Content = content;
            // newIssue.Score = 0;

            Issue createdIssue = new Issue(title, content);
            issues.Add(createdIssue);
            
            // for(int i = 0; i < issues.Count; i++)
            // {
            //     Console.WriteLine(issues[i]);
            // }

            foreach(Issue issueToDisplay in issues)
            {
                Console.WriteLine(issueToDisplay);
            }

            Another:
            Console.WriteLine("Do you want to enter another? [Y/N]");
            string enterAnother = Console.ReadLine() ?? "";
            if(String.IsNullOrWhiteSpace(enterAnother))
            {
                Console.WriteLine("Please enter valid input");
                goto Another;
            }
            char responseChar = enterAnother.Trim().ToUpper()[0];

            if(responseChar == 'N')
            {
                Console.WriteLine("Goodbye!");
                exit = true;
            }
            else if(responseChar != 'Y')
            {
                Console.WriteLine("Please enter valid response");
                goto Another;
            }
        }while(!exit);

    }
}