namespace BL;

public interface IBL
{
    List<Restaurant> SearchRestaurants(string searchString);

    List<Restaurant> GetAllRestaurants();

    void AddRestaurant(Restaurant restaurantToAdd);

    void AddReview(int restaurantId, Review reviewToAdd);

}