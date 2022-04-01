namespace UI;
public class MainMenu : IMenu {
    private IBL _bl;

    public MainMenu(IBL bl)
    {
        _bl = bl;
    }

    public void Start() {
        bool exit = false;
        Console.WriteLine("Welcome to Restaurant Reviews!");

        while(!exit)
        {
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("[1] Manage Restaurant");
            Console.WriteLine("[2] Review Menu");
            Console.WriteLine("[x] Exit");
            string? input = Console.ReadLine();

            //Null Coalescing operators
            //string input = Console.ReadLine() ?? "";
            // input ??= "";

            if(!string.IsNullOrWhiteSpace(input))
            {
                switch (input)
                {
                    case "1":
                        MenuFactory.GetMenu("restaurant").Start();
                    break;
                    case "2":
                        MenuFactory.GetMenu("review").Start();
                    break;
                    case "x":
                        exit = true;
                        Console.WriteLine("goodbye!");
                    break;

                }
            }
            else
            {
                Console.WriteLine("Please enter valid input");
            }
        }
    }
}
