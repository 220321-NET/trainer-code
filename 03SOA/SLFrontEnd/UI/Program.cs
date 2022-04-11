using UI;

HttpService http = new HttpService();
await new MainMenu(http).Start();
