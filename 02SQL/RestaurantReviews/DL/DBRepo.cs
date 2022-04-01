using Microsoft.Data.SqlClient;
//To get the above namespace working, run
//dotnet add package Microsoft.Data.Sqlclient
using System.Data;
//Include this namespace to be able to use DataSet
namespace DL;

public class DBRepo : IRepo
{
    private string _connectionString;
    public DBRepo(string connectionString) {
        _connectionString = connectionString;
    }

    /*
        We'll be using ADO.NET to connect our app to DB
        ADO.NET is collection of classes that allows us to work with
        various data sources in uniform fashion (SQL, OLE DB, XML, etc)
        4 Parts:
        1. Establish Connection
        2. Write the query you want to run
        3. Run it
        4. Process the data you get from it to C# object that rest of your app can consume
    */

    //ADO.NET: Disconnected Architecture saves data in memory
    //in DataSet, that persists outside of connection using DataAdapters
    //Data Adapters also manage connection for us
    //So we don't need to connect/disconnect manually
    //This is useful if you want to do more complex data manipulation
    //And C,U,D operation (Create, Update, Delete)
    //In order to work with data adapters,
    //We first give select statement to data adapter when we first set it up to get the table information and initial dataset
    //And then we do futher op on those dataset
    //and call Update method on the adapter.
    public void AddRestaurant(Restaurant restaurantToAdd)
    {
        DataSet restoSet = new DataSet();
        string selectCmd = "SELECT * FROM Restaurant WHERE Id = -1";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {
                //DataSet is essentially just a container that holds data in memory
                //it holds one or more DataTables

                //We can fill that DataSet using SqlDataAdapter.Fill method
                dataAdapter.Fill(restoSet, "Restaurant");

                DataTable restoTable = restoSet.Tables["Restaurant"];
                
                //If you want to get the information on Data you queried when you called Fill method, we can iterate through DataTable.Rows property (has DataRow collection)
                //If you want info about the column (name, etc), iterate DataTable.Columns (that has DataColumn collection)
                //run debugger on them or docs/tutorials for more info
                // foreach(DataRow row in restoTable.Rows)
                // {
                //     Console.WriteLine(row["Id"]);
                // }

                //Generate a new row with the Restaurant Table Schema
                DataRow newRow = restoTable.NewRow();
                
                restaurantToAdd.ToDataRow(ref newRow);
                //Fill the new row with the new restaurant information
                // newRow["Name"] = restaurantToAdd.Name;
                // newRow["City"] = restaurantToAdd.City ?? "";
                // newRow["State"] = restaurantToAdd.State ?? "";

                //add the new row to our restaurantTable Rows
                restoTable.Rows.Add(newRow);

                //We need to set which query to execute for changes
                //We need to set SqlDataAdapter.InsertCommand to let it know
                //How to insert the new records it sees in the restoTable
                string insertCmd = $"INSERT INTO Restaurant (Name, City, State) VALUES ('{restaurantToAdd.Name}', '{restaurantToAdd.City}', '{restaurantToAdd.State}')";

                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);

                //We have to tell the data adapter how to insert records (it's not magic)
                //We can either generate this command by manually typing it out or using SqlCommandBuilder
                // dataAdapter.InsertCommand = new SqlCommand(insertCmd, connection);
                dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();
                
                //SqlDataAdapter.UpdateCommand (for your Put/Update operations)
                // dataAdapter.UpdateCommand = cmdBuilder.GetUpdateCommand();

                //SqlDataAdapter.DeleteCommand (for your Delete Operations)
                // dataAdapter.DeleteCommand = cmdBuilder.GetDeleteCommand();
                //Tell the dataAdapter to update the DB with changes
                dataAdapter.Update(restoTable);
            }
        }
    }

    /// <summary>
    /// Adds a new review to Review Table
    /// </summary>
    /// <param name="restaurantId">Id of the restaurant to add the review for</param>
    /// <param name="reviewToAdd">Review object to be added</param>
    public void AddReview(int restaurantId, Review reviewToAdd)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "INSERT INTO Review (RestaurantId, Rating, NOTE) VALUES (@restoId, @rating, @note)";

            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                SqlParameter param = new SqlParameter("@restoId", restaurantId);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@rating", reviewToAdd.Rating);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@note", reviewToAdd.Note);
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
        
        
    }

    public List<Restaurant> GetAllRestaurants()
    {
        List<Restaurant> allRestaurants = new List<Restaurant>();

        using SqlConnection connection = new SqlConnection(_connectionString);
        string restoSelect = "Select * From Restaurant";
        string reviewSelect = "Select * From Review";
        
        //A single dataSet to hold all our data
        DataSet RRSet = new DataSet();

        //Two different adapters for different tables
        using SqlDataAdapter restoAdapter = new SqlDataAdapter(restoSelect, connection);
        using SqlDataAdapter reviewAdapter = new SqlDataAdapter(reviewSelect, connection);

        restoAdapter.Fill(RRSet, "Restaurant");
        reviewAdapter.Fill(RRSet, "Review");

        DataTable? RestaurantTable = RRSet.Tables["Restaurant"];
        DataTable? ReviewTable = RRSet.Tables["Review"];

        if(RestaurantTable != null && ReviewTable != null)
        {   
            foreach(DataRow row in RestaurantTable.Rows)
            {
                Restaurant resto = new Restaurant(row);
                // resto.Id = (int) row["Id"];
                // resto.Name = row["Name"].ToString() ?? "";
                // resto.City = row["City"].ToString() ?? "";
                // resto.State = row["State"].ToString() ?? "";

                //LINQ: Language Integrated Query
                //ReviewTable.AsEnumerable() got me IEnumerable<DataRow>
                //The Where clause/method is filtering for only reviews that has RestaurantId value as the current restaurant's Id
                //In Select method, we are taking all the data we have in the collection and transforming into some shape. In this case we are taking the datarow and then turning it into Review object (with lambda expression)
                //After the Select method, we have IEnumerable Collection of Review Objects
                //But we ultimately want to have a list of Reviews, so we convert IEnumerable to List by using ToList()
                //Finally, we assign this List<Review> to resto.Reviews

                resto.Reviews = ReviewTable.AsEnumerable().Where(r => (int) r["RestaurantId"] == resto.Id).Select(
                    r =>
                        new Review {
                            Id = (int) r["Id"],
                            RestaurantId = (int) r["RestaurantId"],
                            Rating = (int) r["Rating"],
                            Note = r["NOTE"].ToString() ?? ""
                        }
                ).ToList();

                // foreach(DataRow reviewRow in ReviewTable.Rows)
                // {
                //     if((int) reviewRow["RestaurantId"] == resto.Id)
                //     {
                //         Review review = new Review();

                //         review.Id = (int) reviewRow["Id"];
                //         review.RestaurantId = (int) reviewRow["RestaurantId"];
                //         review.Rating = (int) reviewRow["Rating"];
                //         review.Note = reviewRow["NOTE"].ToString() ?? "";

                //         resto.Reviews.Add(review);
                //     }
                // }

                allRestaurants.Add(resto);
            }
        }
        return allRestaurants;
    }

    //This is a way to grab all restaurants using DataReader
    // public List<Restaurant> GetAllRestaurants()
    // {
    //     List<Restaurant> allRestaurants = new List<Restaurant>();
    //     using(SqlConnection connection = new SqlConnection(_connectionString))
    //     {
    //         //Opening the connection to DB
    //         connection.Open();

    //         //assembling our query to query the db with
    //         string queryTxt = "SELECT * FROM Restaurant";
    //         //take the query text and connection we've built, and get ourselves
    //         //SqlCommand object that is capable of executing the command
    //         //on a particular SQL DB we specify.
    //         using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
    //         {
    //             //Get the result of the command via SqlDataReader
    //             //SqlDataReader is part of what we call Connected Architecture
    //             //in ADO.NET
    //             //Data only exists while the connection is alive
    //             //And is not cached in memory
    //             //Efficient when working with large dataset because we are not storing all the data in our memory

    //             using(SqlDataReader reader = cmd.ExecuteReader())
    //             {
    //                 while(reader.Read())
    //                 {   
    //                     Restaurant resto = new Restaurant();
    //                     resto.Id = reader.GetInt32(0);
    //                     resto.Name = reader.GetString(1);
    //                     resto.City = reader.GetString(2);
    //                     resto.State = reader.GetString(3);

    //                     allRestaurants.Add(resto);
    //                 }
    //             }
    //         }
    //         //closing the connection to DB
    //         connection.Close();
    //     }

    //     return allRestaurants;
    // }

    /// <summary>
    /// Search for restaurant by either name, city, or state
    /// </summary>
    /// <param name="searchTerm">string param to search restaurants by</param>
    /// <returns>List of Restaurants that contains the search term, an empty list otherwise</returns>
    public List<Restaurant> SearchRestaurants(string searchTerm)
    {
        string searchQuery = $"SELECT * FROM Restaurant WHERE Name LIKE '%{searchTerm}%' OR City LIKE '%{searchTerm}%' OR State LIKE '%{searchTerm}%'";

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand(searchQuery, connection);
        using SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //Getting ourselves a bucket for our data
        DataSet restaurantSet = new DataSet();

        //Telling the data adapter to fill our dataset
        adapter.Fill(restaurantSet, "Restaurant");

        //Our result of executing the searchQuery
        DataTable restaurantTable = restaurantSet.Tables["Restaurant"];

        List<Restaurant> searchResult = new List<Restaurant>();

        //Processing data from rows of data to list of restaurants
        //so rest of our app can consume
        foreach(DataRow row in restaurantTable.Rows)
        {
            Restaurant resto = new Restaurant(row);
            searchResult.Add(resto);
        }

        return searchResult;
    }

    /// <summary>
    /// Search for the restaurant for exact match of name, city, and state
    /// </summary>
    /// <param name="restaurant">restaurant object to search for dup</param>
    /// <returns>bool: true if there is duplicate, false if not</returns>
    public bool IsDuplicate(Restaurant restaurant)
    {
        string searchQuery = $"SELECT * FROM Restaurant WHERE Name='{restaurant.Name}' AND City='{restaurant.City}' AND State='{restaurant.State}'";
        
        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand(searchQuery, connection);

        connection.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        if(reader.HasRows)
        {
            //Query returned something, there exists a record that shares the same name, city, and state to the restaurant the user is trying to create 
            return true;
        }
        //no record was returned. No duplicate record in the db
        return false;
    }
}