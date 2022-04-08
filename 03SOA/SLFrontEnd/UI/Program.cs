using UI;
// using BL;
// using DL;


// string connectionString = File.ReadAllText("./connectionString.txt");

//Dependency Injection
// IRepository repo = new DBRepository(connectionString);
// ISLBL bl = new SLBL(repo);
HttpService http = new HttpService();
await new MainMenu(http).Start();

// //Equivalent to ^
// new MainMenu(new SLBL(new FileRepository())).Start();