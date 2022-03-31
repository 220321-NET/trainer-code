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
    Issue CreateIssue(Issue issueToCreate);

    /// <summary>
    /// Retrieves all issues
    /// </summary>
    /// <returns>List of issues, if empty, returns an empty list</returns>
    List<Issue> GetAllIssues();

    /// <summary>
    /// Updates answers property of the issue object
    /// </summary>
    /// <param name="issueToUpdate">the issue object that has new answers</param>
    void AddAnswer(Answer answerToAdd);

    /// <summary>
    /// Gets all records from Issues table with Answers associated to the issue
    /// </summary>
    /// <returns>The list of issue with answers, an empty list if there is none</returns>
    List<Issue> GetIssuesWithAnswers();

    /// <summary>
    /// Looks for an issue record by its id
    /// </summary>
    /// <param name="id">Id of the Issue</param>
    /// <returns>The found issue, if not null</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    Issue? GetIssueById(int id);
}