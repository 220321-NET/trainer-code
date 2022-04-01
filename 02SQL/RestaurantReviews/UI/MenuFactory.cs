using DL;

namespace UI;
public static class MenuFactory
{
    public static IMenu GetMenu(string menuString)
    {
        menuString = menuString.ToLower();
        //This is full dep injection
        // new RestaurantMenu(new RRBL(new FileRepo())).Start();
        
        //Here, I instantiated an implementation of IRepo (FileRepo)

        //We are changing only this line to swap out FileRepo to DBRepo
        //But before we do that, we need to read connection string from file first
        string connectionString = File.ReadAllText("connectionString.txt");
        IRepo repo = new DBRepo(connectionString);
        //next, I instantiated RRBL (an implementation of IBL) and then injected IRepo implementation for IBL/RRBL
        IBL bl = new RRBL(repo);
        //Finally, I instantiate RestaurantMenu that needs an instance that implements Business Logic class
        switch (menuString)
        {
            case "main":
                return new MainMenu(bl);

            case "restaurant":
                return new RestaurantMenu(bl);
            
            case "review":
                return new ReviewMenu(bl);
            
            default:
                return new MainMenu(bl);
        }
    }
}