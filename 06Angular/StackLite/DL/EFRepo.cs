namespace DL;

public class EFRepo : IRepository
{
    public void AddAnswer(Answer answerToAdd)
    {
        throw new NotImplementedException();
    }

    public Issue CreateIssue(Issue issueToCreate)
    {
        throw new NotImplementedException();
    }

    public Task<List<Issue>> GetAllIssuesAsync()
    {
        throw new NotImplementedException();
    }

    public Issue? GetIssueById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Issue> GetIssuesWithAnswers()
    {
        throw new NotImplementedException();
    }

    public void UpdateIssue(Issue issueToUpdate)
    {
        throw new NotImplementedException();
    }
}