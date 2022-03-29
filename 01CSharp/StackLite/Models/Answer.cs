namespace Models;

public class Answer : TextEntry
{
    
    public bool IsAccepted { get; set; }

    public override string ToString()
    {
        return $"Date Created: {DateCreated} \nContent: {Content} \nScore: {Score} \nAccepted: {IsAccepted}";
    }
}
