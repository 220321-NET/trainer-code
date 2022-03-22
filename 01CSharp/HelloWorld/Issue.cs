namespace StackLite;

public class Issue {
    public Issue()
    {
        Score = 0;
        _title = "";
        Content = "";
    }

    //Example of Constructor Overloading and chaining
    public Issue(string title, string content) : this()
    {
        _title = title;
        Content = content;
    }

    //type member: field
    //fields holds data
    // private string title;

    // //getter: returns field's data
    // public string GetTitle()
    // {
    //     return title;
    // }

    // //Setter: sets the field
    // public void SetTitle(string titleToSet)
    // {
    //     title = titleToSet;
    // }

    //Automatic property (or just property)
    private string _title;
    public string Title 
    { 
        get
        {
            return _title;
        }
        set
        {
            Console.WriteLine("I'm currently in setter");
            _title = value;
        }
    }

    public string Content { get; set; }

    public int Score { get; set; }

    public void UpVote()
    {
        Score++;
    }

    public void DownVote()
    {
        Score--;
    }

    public override string ToString()
    {
        return $"Title: {this.Title} \nContent: {this.Content} \nScore: {this.Score}";
    }
}