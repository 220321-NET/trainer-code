using Xunit;
using Models;
using BL;
using Moq;
using DL;

namespace Tests;

public class SLBLTests
{
    [Fact]
    public void CreateIssueShouldCreate()
    {
        //Arrange Act Assert pattern
        //Arranging
        var mockDL = new Mock<IRepository>();

        Issue testQuestion = new Issue {
            Title = "Test Title",
            Content = "Test Content"
        };

        Issue expectedResponse = new Issue {
            Id = 4,
            Title = "Test Title",
            Content = "Test Content",
            Score = 0,
            DateCreated = DateTime.Now,
            IsClosed = false
        };
        mockDL.Setup(dl => dl.CreateIssue(testQuestion))
              .Returns(expectedResponse);

        SLBL bl = new SLBL(mockDL.Object);

        //Act
        Issue response = bl.CreateIssue(testQuestion);

        //Assert
        Assert.Equal(expectedResponse.Title, testQuestion.Title);
        Assert.Equal(expectedResponse.Content, testQuestion.Content);

        Assert.True(response.Equals(expectedResponse));
        mockDL.Verify(dl => dl.CreateIssue(testQuestion), Times.Once());
        // Assert.Equal(response.Id, expectedResponse.Id);
        // Assert.Equal(response.Score, expectedResponse.Score);
        // Assert.Equal(response.IsClosed, expectedResponse.IsClosed);
    }
    
    [Fact]
    public async Task GetAllIssuesShouldGetAllIssues()
    {
        List<Issue> fakeData = new List<Issue>() {
        new Issue {
            Title = "Null Reference Exception",
            Content = "I keep getting null reference exception, what is this?",
            Answers = new List<Answer>{
                new Answer {
                    Content = "You are trying to pass in nothing. Make sure variables are set earlier"
                }
            }
        },
        new Issue {
            Title = "My intellicode doesn't work :(",
            Content = "I am not getting any help from my code editor, this is getting old, please help",
            Answers = new List<Answer>{
                new Answer {
                    Content = "I am having the same problem"
                }
            }
            
        },
        new Issue {
            Title = "type not found, are you missing using directive?",
            Content = "see the error above, I don't know what's going on",
            Answers = new List<Answer>{
                new Answer {
                    Content = "I was able to fix this by testing it in my VM but Idk how to explain it"
                }
            }
        },
        new Issue {
            Title = "mismatched typing",
            Content = "I keep getting this error, please check you are entering the right type of input, what do i do?",
            Answers = new List<Answer>{
                new Answer {
                    Content = "Make sure if you are trying to enter an integer that you want to output an integer. This is also true for any other primitive types"
                }
            }
        },
        new Issue {
            Title = "array out of bound exception",
            Content = "I was looping through an array and i got this exception",
            Answers = new List<Answer>{
                new Answer {
                    Content = "You are trying to access indexes that are passed the size of the array"
                }
            }
        },
        new Issue {
            Title = "failed to push some refs to...",
            Content = "I tried to push my files, and this popped up nvm i got it",
            Answers = new List<Answer>{
                new Answer {
                    Content = "Cool"
                }
            }
        }
    };
        var mockDL = new Mock<IRepository>();
        mockDL.Setup(dl => dl.GetAllIssuesAsync())
                .ReturnsAsync(fakeData);

        SLBL bl = new SLBL(mockDL.Object);

        List<Issue> issues = await bl.GetIssuesAsync();

        Assert.NotEmpty(issues);
        Assert.Equal(6, issues.Count);
        mockDL.Verify(dl => dl.GetAllIssuesAsync(), Times.Exactly(1));
    }
}

