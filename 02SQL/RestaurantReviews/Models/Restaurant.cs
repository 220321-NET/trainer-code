using CustomExceptions;
using System.Text.RegularExpressions;
using System.Data;

namespace Models;

public class Restaurant {
    //In a restaurant, I want to store name, city, state of a restaurant

    //This is property, a type member
    //Access modifier controls the visibility of type and type members.
    //There are four access modifiers: Public, Private, Internal, Protected
    //public is the most visible, private is the least visible
    //By default, class member has private access modifier
    //Class, by default, are internal unless you explicitely say otherwise

    public Restaurant()
    {
        this.Reviews = new List<Review>();
    }
    public Restaurant(string name)
    {
        this.Reviews = new List<Review>();
        this._name = name;
    }

    /// <summary>
    /// Converting Restaurant table's data row into Restaurant Object
    /// </summary>
    /// <param name="row">a data row from Restaurant object, must have id, name, city, state columns</param>
    public Restaurant(DataRow row)
    {
        this.Id = (int) row["Id"];
        this.Name = row["Name"].ToString() ?? "";
        this.City = row["City"].ToString() ?? "";
        this.State = row["State"].ToString() ?? "";
    }

    public int Id { get; set; }

    private string _name;
    public string Name {
        get => _name;
        set
        {
            Regex pattern = new Regex("^[a-zA-Z0-9 !?']+$");
            if(string.IsNullOrWhiteSpace(value))
            {
                //we're checking whether this string is null or whitespace
                throw new InputInvalidException("Name can't be empty");
            }
            //even if the string is not null or white space,
            //we can still check for the name's validity by using RegEx (Regular Expression)
            //Regular Expression is a way to pattern match a string for a certain condition
            //it has a confusing syntax, so I recommend looking up language specific RegEx reference page to build one
            else if(!pattern.IsMatch(value))
            {
                throw new InputInvalidException("Restaurant name can only have alphanumeric characters, white space, !, ?, and '.");
            }
            else
            {
                this._name = value;
            }
        } 
    }


    // //our own custom getter and setter for the private backing field
    // public string GetName() {
    //     return this._name;
    // }
    // public void SetName(string name)
    // {
    //     //input validation
    //     if(name == "")
    //     {
    //         Console.WriteLine("Name Cannot Be Empty");
    //     }
    //     this._name = name;
    // }

    // private string _city;

    public string City { get; set; }
    public string State { get; set; }
    public List<Review> Reviews { get; set; }

    public override string ToString()
    {
        return $"Id: {this.Id} \nName: {this.Name} \nCity: {this.City} \nState: {this.State}";
    }

    /// <summary>
    /// Takes in Restaurant Table's DataRow and fills the columns with the Restaurant Instance's info
    /// </summary>
    /// <param name="row">Restaurant Table's DataRow pass by ref</param>
    public void ToDataRow(ref DataRow row)
    {
        row["Name"] = this.Name;
        row["City"] = this.City;
        row["State"] = this.State;
    }
}