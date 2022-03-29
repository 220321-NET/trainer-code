namespace BL;

public interface ISLBL
{
    void CreateIssue(Issue issueToCreate);

    List<Issue> GetIssues();

    void DeletedIssue(Issue issueToDelete);

    void AddAnswer(Issue issueToUpdate);
}