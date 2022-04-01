using Xunit;
using Models;
using CustomExceptions;
using System.Collections.Generic;

//Make sure you have your projects and namespaces you need here
namespace Tests;

public class ModelsTest
{
    [Fact]
    public void RestaurantShouldCreate()
    {
        //Arrange
        //In this case, the arrange step, was making sure that I had my Models namespace included here.

        //Act: Creating the restaurant object
        Restaurant testRestaurant = new Restaurant();

        //Assert: assert that my testRestaurant actually created and is not null
        Assert.NotNull(testRestaurant);
    }

    [Fact]
    public void RestaurantShouldSetValidData()
    {
        //Arrange
        Restaurant testRestaurant = new Restaurant();
        string name = "Test Name";
        string city = "Test City";
        string state = "Test State";

        //Act
        testRestaurant.Name = name;
        testRestaurant.City = city;
        testRestaurant.State = state;

        //Assert
        Assert.Equal(name, testRestaurant.Name);
        Assert.Equal(city, testRestaurant.City);
        Assert.Equal(state, testRestaurant.State);
    }

    [Theory]
    [InlineData("#$%^@#$%#@")]
    [InlineData("     ")]
    [InlineData(null)]
    [InlineData("")]
    public void RestaurantShouldNotSetInvalidName(string input)
    {
        //For this test, I'm going to make sure when I try to set invalid name
        //Restaurant class will throw InputInvalidException

        //Arrange: I'm going to have a test restaurant object and invalid string to attempt to set it as the name
        Restaurant testRestaurant = new Restaurant();

        //Act: I'm going to try and setting invalid name as the restaurant.Name
        //Assert: Assert that Restaurant class throws an Exception
        Assert.Throws<InputInvalidException>(() => testRestaurant.Name = input);
    }

    [Fact]
    public void RestaurantShouldHaveCustomToStringMethod()
    {
        //Arrange: the restaurant with its properties, and the expected ToString output
        Restaurant testRestaurant = new Restaurant{
            Name = "Test Restaurant",
            City = "Test City",
            State = "Test State"
        };
        string expectedOutput = "Name: Test Restaurant \nCity: Test City \nState: Test State";

        //Act: call ToString Method
        //Assert: the output of ToString Method is equal to the expected output
        Assert.Equal(expectedOutput, testRestaurant.ToString());
    }

    [Fact]
    public void RestaurantReviewsShouldBeAbleToBeSet()
    {
        //Arrange: my test restaurant, and my list of reviews
        Restaurant testRestaurant = new Restaurant();
        List<Review> testReviews = new List<Review>();
        int testReviewCount = 0;
        
        //Act: setting my reviews list to the restaurant
        testRestaurant.Reviews = testReviews;

        //Assert: that my Reviews property of the test restaurant is not null and has the the number of items that i expect it to contain
        Assert.NotNull(testRestaurant.Reviews);
        Assert.Equal(testReviewCount, testRestaurant.Reviews.Count);
    }
}

/* Code Coverage:
Code coverage is a metric that quantifies how much of our code base has been
"covered" by unit tests
- 3 different metrics that xunit coverlet supports: Line, Branch, Methods
- Line: how many lines of code has your unit tests testing?
- Branch: different scenarios that can happen at every decision point
- Methods: checks individual methods in classes for the coverage

By default, Coverlet (which calculates the code coverage metrics) generates Cobertura file as the coverage report format
*/