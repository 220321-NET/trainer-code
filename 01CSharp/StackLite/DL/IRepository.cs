namespace DL;

/// <summary>
/// Interface for accessing data in StackLite
/// </summary>
public interface IRepository
{
    /// <summary>
    /// adds a new issue
    /// </summary>
    /// <param name="issueToCreate">Issue object to be inserted</param>
    void CreateIssue(Issue issueToCreate);

    /// <summary>
    /// Retrieves all issues
    /// </summary>
    /// <returns>List of issues, if empty, returns an empty list</returns>
    List<Issue> GetAllIssues();

    /// <summary>
    /// Updates answers property of the issue object
    /// </summary>
    /// <param name="issueToUpdate">the issue object that has new answers</param>
    void AddAnswer(Issue issueToUpdate);
}