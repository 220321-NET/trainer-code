namespace DL;
public static class StaticStorage
{
    public static List<Issue> Issues { get; set; } = new List<Issue>() {
        new Issue {
            Title = "Null Reference Exception",
            Content = "I keep getting null reference exception, what is this?"
        },
        new Issue {
            Title = "My intellicode doesn't work :(",
            Content = "I am not getting any help from my code editor, this is getting old, please help"
        },
        new Issue {
            Title = "type not found, are you missing using directive?",
            Content = "see the error above, I don't know what's going on"
        },
        new Issue {
            Title = "mismatched typing",
            Content = "I keep getting this error, please check you are entering the right type of input, what do i do?"
        },
        new Issue {
            Title = "array out of bound exception",
            Content = "I was looping through an array and i got this exception"
        },
        new Issue {
            Title = "failed to push some refs to...",
            Content = "I tried to push my files, and this popped up nvm i got it"
        }
    };
}