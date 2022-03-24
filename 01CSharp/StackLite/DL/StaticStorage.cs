using Models;

namespace DL;
public static class StaticStorage
{
    public static List<Issue> Issues { get; set; } = new List<Issue>() {
        new Issue {
            Title = "Null Reference Exception",
            Content = "I keep getting null reference exception, what is this?",
            Answers = "You are trying to pass in nothing. Make sure variables are set earlier"
        },
        new Issue {
            Title = "My intellicode doesn't work :(",
            Content = "I am not getting any help from my code editor, this is getting old, please help",
            Answers = "I am having the same problem"
        },
        new Issue {
            Title = "type not found, are you missing using directive?",
            Content = "see the error above, I don't know what's going on",
            Answers = "I was able to fix this by testing it in my VM but Idk how to explain it"
        },
        new Issue {
            Title = "mismatched typing",
            Content = "I keep getting this error, please check you are entering the right type of input, what do i do?",
            Answers = "Make sure if you are trying to enter an integer that you want to output an integer. This is also true for any other primitive types"
        },
        new Issue {
            Title = "array out of bound exception",
            Content = "I was looping through an array and i got this exception",
            Answers = "You are trying to access indexes that are passed the size of the array"
        },
        new Issue {
            Title = "failed to push some refs to...",
            Content = "I tried to push my files, and this popped up nvm i got it",
            Answers = "Cool"
        }
    };
}