using CustomExceptions;

namespace BL;
public class RRBL : IBL
{
    private IRepo _dl;

    public RRBL(IRepo repo)
    {
        _dl = repo;
    }

    /// <summary>
    /// Gets all restaurants
    /// </summary>
    /// <returns>list of all restaurants</returns>
    public List<Restaurant> GetAllRestaurants()
    {
        return _dl.GetAllRestaurants();
    }

    /// <summary>
    /// Adds a new restaurant to the list
    /// </summary>
    /// <param name="restaurantToAdd">restaurant object to add</param>
    public void AddRestaurant(Restaurant restaurantToAdd)
    {
        if(!_dl.IsDuplicate(restaurantToAdd))
        {
            _dl.AddRestaurant(restaurantToAdd);
        }
        else throw new DuplicateRecordException("A restaurant with same name, city, and state already exists!");
    }

    /// <summary>
    /// Adds a new review to the restaurant that exists on that index
    /// </summary>
    /// <param name="restaurantId">index of the restaurant to leave a review for</param>
    /// <param name="reviewToAdd">a review object to be added to the restaurant</param>
    public void AddReview(int restaurantId, Review reviewToAdd)
    {
        _dl.AddReview(restaurantId, reviewToAdd);
    }

    public List<Restaurant> SearchRestaurants(string searchTerm)
    {
        return _dl.SearchRestaurants(searchTerm);
    }
}
