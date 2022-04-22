namespace BL;

public interface ISLBL
{
    Issue CreateIssue(Issue issueToCreate);

    Task<List<Issue>> GetIssuesAsync();

    List<Issue> GetIssuesWithAnswers();

    void DeletedIssue(Issue issueToDelete);

    Task<Answer> AddAnswerAsync(Answer answerToAdd);

    Task<List<Issue>> SearchIssueAsync(string searchString);

    void CloseIssue(Issue issueToClose);

    Issue? GetIssueById(int issueId);
}