using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Models;

namespace Tests;

public class IssueTests
{
    [Fact]
    public void IssueShouldSetValidTitle()
    {
        //Arrange
        //I arranged for this test by creating a new issue to set the title as
        Issue testIssue = new Issue();

        //Act
        testIssue.Title = "Test Title";

        //Assert that testIssue's title is the thing that we set
        Assert.Equal("Test Title", testIssue.Title);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("             ")]
    public void IssueShouldNotSetInvalidTitle(string input)
    {
        //Arrange
        //I arranged for this test by creating a new issue to set the title as
        Issue testIssue = new Issue();

        //Act(try to set the title as invalid input, and Assert that testIssue throws the expected exception
        Assert.Throws<ValidationException>(() => testIssue.Title = input);
    }

    [Fact]
    public void IssueShouldSetValidContent()
    {
        //Arrange
        //I arranged for this test by creating a new issue to set the title as
        Issue testIssue = new Issue();

        //Act
        testIssue.Content = "Test Content";

        //Assert that testIssue's title is the thing that we set
        Assert.Equal("Test Content", testIssue.Content);
    }

    [Fact]
    public void IssueShouldSetAnswers()
    {
        //Arrange
        Issue testIssue = new Issue();
        List<Answer> answers = new List<Answer> {
            new Answer {
                Content = "Test Answer"
            },
            new Answer {
                Content = "Another test Answer"
            }
        };

        //Act
        testIssue.Answers = answers;

        //Assert
        Assert.NotNull(testIssue.Answers);
        Assert.Equal(2, testIssue.Answers.Count);
    }

    [Fact]
    public void IssueShouldUpVote()
    {
        //call upvote, score changes. change the score, not the answers

        //arrange
        Issue _issue = new Issue();
        //act
        
        _issue.UpVote();
        
        //assert
        Assert.Equal(1,_issue.Score);
    }

    [Fact]
    public void IssueShouldHaveCustomToStringMethod()
    {
        //Arrange
        DateTime newDate = DateTime.Now;
        Issue question = new Issue {
            Title = "Test Question",
            Content = "Test Content",
            DateCreated = newDate,
            Score = 200
        };

        string expectedString = 
        $"Title: Test Question \nDate Created: {newDate} \nContent: Test Content \nScore: 200";

        //Act & Assert
        Assert.Equal(expectedString, question.ToString());
    }
}