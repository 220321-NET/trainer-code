using DL;
namespace BL;

public class SLBL : ISLBL
{
    private readonly IRepository _repo;
    public SLBL(IRepository repo)
    {
        _repo = repo;
    }
    public void CreateIssue(Issue issueToCreate)
    {
        _repo.CreateIssue(issueToCreate);
    }

    public List<Issue> GetIssues()
    {
        return _repo.GetAllIssues();
    }

    public void DeletedIssue(Issue issueToDelete)
    {
        StaticStorage.Issues.Remove(issueToDelete);
    }

    public void AddAnswer(Issue issueToUpdate)
    {
        _repo.AddAnswer(issueToUpdate);
    }
}