using System.ComponentModel.DataAnnotations;

namespace Models;
public class Issue : TextEntry
{
    private string title = "";
    public string Title 
    { 
        get => title;
        set
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException("title cannot be empty");
            }
            title = value;
        }
    }

    public bool IsClosed { get; set; }

    public string Answers { get; set; }

    public override string ToString()
    {
        return $"Title: {Title} \nDate Created: {DateCreated} \nContent: {Content} \nScore: {Score} \nAnswers: {Answers}";
    }
    public void displayAnswers(){
        Console.WriteLine(Answers);
    }
}