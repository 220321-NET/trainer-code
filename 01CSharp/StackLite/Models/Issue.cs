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

    public List<Answer> Answers { get; set; } = new List<Answer>();
    

    public override string ToString()
    {
        return $"Title: {Title} \nDate Created: {DateCreated} \nContent: {Content} \nScore: {Score}";
    }

    public async void GetAnswers()
    {
        for (int i = 0; i < Answers.Count; i++)
        {
            Console.WriteLine("Answer #" + (i + 1) + ":");
            Console.WriteLine(Answers[i].Content + "\n");
        }
    }

}