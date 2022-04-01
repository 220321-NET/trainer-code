using CustomExceptions;

namespace Models;

public class Review {

    //empty constructor
    public Review() { }

    //Example of constructor overloading
    public Review(int rating)
    {
        this.Rating = rating;
    }

    public Review(int rating, string note)
    {
        this.Rating = rating;
        this.Note = note;
    }

    public int Id { get; set; }

    public int RestaurantId { get; set; }

    private int _rating;
    public int Rating
    {
        get => _rating;
        //For the setter, we are checking that the rating is between 1 and 5
        set
        {
            if(value <= 0 || value > 5)
            {
                throw new InputInvalidException("Rating must be between 1 and 5");
            }
            this._rating = value;
        }
    }
    public string Note { get; set; }

    //override Review's ToString Method for me here
    //That outputs $"Rating: {review.Rating} \t Note: {review.Note}"

    public override string ToString()
    {
        return $"Rating: {this.Rating} \t Note: {this.Note}";
    }
}