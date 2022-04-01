using CustomExceptions;

namespace UI;

public class ReviewMenu : IMenu
{
    private IBL _bl;
    public ReviewMenu(IBL bl)
    {
        _bl = bl;
    }

    public void Start()
    {
        bool exit = false;
        do
        {
            Console.WriteLine("This is a review menu");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[0] Leave a Review");
            Console.WriteLine("[x] Go Back");

            switch (Console.ReadLine())
            {
                case "0":
                    LeaveReview();
                break;
                case "x":
                    exit = true;
                break;
                default:
                    Console.WriteLine("I don't understand your input");
                break;
            }
        } while(!exit);
    }

    private void LeaveReview()
    {
        List<Restaurant> allRestaurants = _bl.GetAllRestaurants();
        Console.WriteLine("Select a restaurant to leave reviews for");
        for(int i = 0; i < allRestaurants.Count; i++)
        {
            Console.WriteLine($"[{i}] {allRestaurants[i].ToString()}");
        }
        string? input = Console.ReadLine();
        int selection;
        //TryParse method, "tries" to parse the input (either string or char span), and then returns a boolean that indicates whether the parse has been successful or not, instead of throwing an exception when parse doesn't work 

        //it also accepts second argument/parameter with out keyword
        //By default we pass by value to methods
        //But, there 3 ways to pass by reference (ref, in, and out keywords)
        //ref just means, that the param is passed by ref, so actions we take on the variable we pass by ref will be reflected to outside of the method
        //out is basically ref but before function can exit, it needs to initialize or assign a value to out var's
        //in is another pass by reference, you can't modify params passed with in keyword inside the method (so, make sure that whatever you're passing with in keyword is initialized/instantiated before you pass it in) 
        bool parseSuccess = Int32.TryParse(input, out selection);

        if(parseSuccess && selection >= 0 && selection < allRestaurants.Count)
        {
            //if the parse has been successful, then we know that the selection is integer and TryParse was able to convert the string to int successfully
            //And we're making sure that our integer is staying within the bounds of our List
            //now I want to collect information about the review
            createReview:
            Console.WriteLine("Give a rating: ");
            int rating;
            
            bool success = Int32.TryParse(Console.ReadLine(), out rating);
            Console.WriteLine("Leave a Review: ");
            string note = Console.ReadLine() ?? "";

            try
            {
                Review newReview = new Review(rating, note);
                _bl.AddReview(allRestaurants[selection].Id, newReview);
                Console.WriteLine("Your review has been successfully added!");
            }
            catch(InputInvalidException ex)
            {
                Console.WriteLine(ex.Message);
                goto createReview;
            }
        }
    }
}