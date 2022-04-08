using DL;
namespace BL;

public class SLBL : ISLBL
{
    private readonly IRepository _repo;
    public SLBL(IRepository repo)
    {
        _repo = repo;
    }
    public Issue CreateIssue(Issue issueToCreate)
    {
        return _repo.CreateIssue(issueToCreate);
    }

    public async Task<List<Issue>> GetIssuesAsync()
    {
        return await _repo.GetAllIssuesAsync();
    }

    public void DeletedIssue(Issue issueToDelete)
    {
        StaticStorage.Issues.Remove(issueToDelete);
    }

    public void AddAnswer(Answer answerToAdd)
    {
        _repo.AddAnswer(answerToAdd);
    }

    public async Task<List<Issue>> SearchIssueAsync(string searchString)
    {
        List<Issue> allIssues = await _repo.GetAllIssuesAsync();
        /*
        This is an example of using a delegate with lambda expression. We can use delegates to pass in functions as parameters. Predicate, which we are using here, is a special type of delegate where we take in one argument (issue in our case), and return a boolean value. In this lambda expression, we are taking each of the issue in allIssues collection one by one, comparing whether its Title or Content contains our searchString, and returning true if it does, false if it doesn't. FindAll adds the object that the predicate returned true to the list it returns. It is a way to filter the list based on a custom condition.
        */
        return allIssues.FindAll(issue => issue.Title.ToLower().Contains(searchString) || issue.Content.Contains(searchString));
    }

    public void CloseIssue(Issue issueToClose)
    {
        issueToClose.IsClosed = true;
        _repo.UpdateIssue(issueToClose);
    }

    public Issue? GetIssueById(int issueId)
    {
        return _repo.GetIssueById(issueId);
    }

}