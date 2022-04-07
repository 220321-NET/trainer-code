namespace BL;

public interface ISLBL
{
    Issue CreateIssue(Issue issueToCreate);

    List<Issue> GetIssues();

    void DeletedIssue(Issue issueToDelete);

    void AddAnswer(Answer answerToAdd);

    List<Issue> SearchIssue(string searchString);

    void CloseIssue(Issue issueToClose);
}