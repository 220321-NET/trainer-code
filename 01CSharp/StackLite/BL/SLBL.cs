using Models;
using DL;
namespace BL;

public class SLBL
{
    public void CreateIssue(Issue issueToCreate)
    {
        new FileRepository().CreateIssue(issueToCreate);
    }

    public List<Issue> GetIssues()
    {
        new FileRepository().GetAllIssues();
    }
}