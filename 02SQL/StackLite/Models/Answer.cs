namespace Models;

public class Answer : TextEntry
{
    
    public bool IsAccepted { get; set; }

    public int IssueId { get; set; } 

    public override string ToString()
    {
        return $"Id: {Id} Date Created: {DateCreated} \nContent: {Content} \nScore: {Score} \nAccepted: {IsAccepted}";
    }
}
