using Models;
using DL;
namespace BL;

public class SLBL
{
    public void CreateIssue(Issue issueToCreate)
    {
        StaticStorage.Issues.Add(issueToCreate);
    }

    public List<Issue> GetIssues()
    {
        return StaticStorage.Issues;
    }

    public void DeletedIssue(Issue issueToDelete)
    {
        StaticStorage.Issues.Remove(issueToDelete);
    }
}