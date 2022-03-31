using UI;
using BL;
using DL;


string connectionString = File.ReadAllText("./connectionString.txt");

//Dependency Injection
IRepository repo = new DBRepository(connectionString);
Console.WriteLine(repo.GetIssueById(7));

ISLBL bl = new SLBL(repo);
new MainMenu(bl).Start();

// //Equivalent to ^
// new MainMenu(new SLBL(new FileRepository())).Start();