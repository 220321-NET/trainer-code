namespace BL;

public interface ISLBL
{
    void CreateIssue(Issue issueToCreate);

    List<Issue> GetIssues();
}