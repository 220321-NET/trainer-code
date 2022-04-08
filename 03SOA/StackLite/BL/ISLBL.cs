namespace BL;

public interface ISLBL
{
    Issue CreateIssue(Issue issueToCreate);

    Task<List<Issue>> GetIssuesAsync();

    void DeletedIssue(Issue issueToDelete);

    void AddAnswer(Answer answerToAdd);

    Task<List<Issue>> SearchIssueAsync(string searchString);

    void CloseIssue(Issue issueToClose);

    Issue? GetIssueById(int issueId);
}