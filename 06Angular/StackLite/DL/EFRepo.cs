using Microsoft.EntityFrameworkCore;
namespace DL;

public class EFRepo : IRepository
{
    // DbContext represents a session with the database. It contains dbset, which is a collection of records, and connection information, and schema, and so on and so forth. 
    private readonly SLDBContext _context;
    public EFRepo(SLDBContext context)
    {
        _context = context;
    }
    public async Task<Answer> AddAnswerAsync(Answer answerToAdd)
    {
        _context.Add(answerToAdd);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return answerToAdd;
    }

    public Issue CreateIssue(Issue issueToCreate)
    {
        _context.Issues.Add(issueToCreate);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
        return issueToCreate;
    }

    public List<Answer> GetAllAnswers()
    {
        return _context.Answers.AsNoTracking().ToList();
    }

    public Task<List<Issue>> GetAllIssuesAsync()
    {
        return _context.Issues.AsNoTracking().ToListAsync();
    }

    public Issue? GetIssueById(int id)
    {
        // FirstOrDefault takes predicate as the argument
        // Predicate is a type of delegate that takes one argument
        // and returns a boolean value
        return _context.Issues.AsNoTracking().FirstOrDefault(issue => issue.Id == id);
    }

    public Task<List<Issue>> SearchIssueAsync(string searchString)
    {
        // Where clause in LINQ also requires passing in a predicate
        return _context.Issues.AsNoTracking().Where(issue => issue.Title.ToLower().Contains(searchString) || issue.Content.ToLower().Contains(searchString)).ToListAsync();
    }

    public List<Issue> GetIssuesWithAnswers()
    {
        return _context.Issues.AsNoTracking().Include("Answers").ToList();
    }

    public void UpdateIssue(Issue issueToUpdate)
    {
        _context.Issues.Update(issueToUpdate);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

}