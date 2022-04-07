using System.ComponentModel.DataAnnotations;

namespace Models;

public abstract class TextEntry
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    private string content = "";
    
    [Required]
    public string Content
    {
        get => content;
        set
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException("Content cannot be empty");
            }
            content = value;
        }
    }

    public int Score { get; set; }

    public void UpVote()
    {
        Score++;
    }

    public void DownVote()
    {
        Score--;
    }
} 