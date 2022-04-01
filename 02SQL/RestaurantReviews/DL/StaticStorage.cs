namespace DL;
public class StaticStorage : IRepo
{
    private static List<Restaurant> _allRestaurants = new List<Restaurant>();

    /// <summary>
    /// Returns all restaurants from _allRestaurants List
    /// </summary>
    /// <returns>all restaurants in the list</returns>
    public List<Restaurant> GetAllRestaurants()
    {
        return StaticStorage._allRestaurants;
    }

    /// <summary>
    /// Adds a new restaurant to the list
    /// </summary>
    /// <param name="restaurantToAdd">new restaurant object to add</param>
    public void AddRestaurant(Restaurant restaurantToAdd)
    {
        StaticStorage._allRestaurants.Add(restaurantToAdd);
    }

    /// <summary>
    /// Adds review object to the restaurant users have selected
    /// </summary>
    /// <param name="restaurantIndex">int, index of the restaurant in the list</param>
    /// <param name="reviewToAdd">Review object to add to the restaurant</param>
    public void AddReview(int restaurantIndex, Review reviewToAdd)
    {
        StaticStorage._allRestaurants[restaurantIndex].Reviews.Add(reviewToAdd);

        //another way to write the line above
        // Restaurant selectedRestaurant = StaticStorage._allRestaurants[restaurantIndex];
        // selectedRestaurant.Reviews.Add(reviewToAdd);
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