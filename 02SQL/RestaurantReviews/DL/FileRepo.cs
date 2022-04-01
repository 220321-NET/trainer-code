using System.Text.Json;

namespace DL;

//This class reads and writes to the file
public class FileRepo : IRepo
{
    public FileRepo()
    { }

    private string filePath = "../DL/Restaurants.json";

    /// <summary>
    /// Gets all restaurants from a file
    /// </summary>
    /// <returns>List of all restaurants</returns>
    public List<Restaurant> GetAllRestaurants()
    {
        string jsonString = "";
        try
        {
            jsonString = File.ReadAllText(filePath);
        }
        catch(FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return JsonSerializer.Deserialize<List<Restaurant>>(jsonString) ?? new List<Restaurant>();
    }

    /// <summary>
    /// Finds and returns restaurant by its index in the list
    /// </summary>
    /// <param name="index">index to search restaurant for</param>
    /// <returns>restaurant object</returns>
    public Restaurant GetRestaurantByIndex(int index)
    {
        List<Restaurant> allRestaurants = GetAllRestaurants();
        // for(int i = 0; i < allRestaurants.Count; i++)
        // {
        //     if(i == index) return allRestaurants[i];
        // }

        return allRestaurants[index];
    }

    /// <summary>
    /// Adds a restaurant to the list and then writes to a file
    /// </summary>
    /// <param name="restToAdd">restaurant object to be added</param>
    public void AddRestaurant(Restaurant restToAdd)
    {
        //First, we're going to grab all the restaurants from the file
        //Second, we'll deserialize as List<Restaurant>
        //Third, we'll use List's Add method to add our new restaurant
        //Lastly, we'll serialize that List<Restaurant> and then write it to the file

        List<Restaurant> allRestaurants = GetAllRestaurants();
        allRestaurants.Add(restToAdd);

        string jsonString = JsonSerializer.Serialize(allRestaurants);
        File.WriteAllText(filePath, jsonString);
    }

    /// <summary>
    /// to add the review for the restaurant to the list in files
    /// </summary>
    /// <param name="restaurantIndex">using restaurantIndex to find the restaurant in our list</param>
    /// <param name="reviewToAdd">review object to add</param>
    public void AddReview(int restaurantIndex, Review reviewToAdd)
    {
        //1. Grab all restaurants
        //2. Find the restaurant by its index
        //3. Append review
        //4. Write to file

        List<Restaurant> allRestaurants = GetAllRestaurants();

        Restaurant selectedRestaurant = allRestaurants[restaurantIndex];
        
        if(selectedRestaurant.Reviews == null)
        {
            selectedRestaurant.Reviews = new List<Review>();
        }
        selectedRestaurant.Reviews.Add(reviewToAdd);

        string jsonString = JsonSerializer.Serialize(allRestaurants);
        File.WriteAllText(filePath, jsonString);
    }

    public List<Restaurant> SearchRestaurants(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public bool IsDuplicate(Restaurant restaurant)
    {
        throw new NotImplementedException();
    }
}