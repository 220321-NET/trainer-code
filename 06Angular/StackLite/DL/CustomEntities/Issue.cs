using Models;
namespace DL.Entities;

public partial class Issue
{
    public Issue(Models.Issue issue)
    {
        this.Id = issue.Id;
        this.Answers = (ICollection<Answer>) issue.Answers;
    }
}