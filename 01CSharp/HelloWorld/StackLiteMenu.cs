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
    //method defines a behavior of a class
    public void MainMenu()
    {
        Console.WriteLine("Welcome to StackLite!");
        Console.WriteLine("What brings you here today?");

        // string? input = Console.ReadLine();

        // if(input == null) {
        //     Console.WriteLine("you didn't type anything!");
        // }

        EnterTitle:
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
        Console.WriteLine("You entered " + createdIssue.ToString());
    }
}