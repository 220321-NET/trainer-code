using System.Net.Http;
using Models;
using System.Text.Json;

namespace UI;
public class HttpService
{
    private readonly string _apiBaseURL = "https://localhost:7223/api/";

    public async Task<List<Issue>> GetAllIssuesAsync()
    {
        List<Issue> issues = new List<Issue>();
        //First, we are going to assemble our url for the resource
        //2nd, we are going to send a GET request to the api endpoint
        //3rd, we are going to deserialize the response and return it to 
        //our caller as List<Issue>

        string url = _apiBaseURL + "Issues";
        HttpClient client = new HttpClient();
        try
        {
            // HttpResponseMessage response = await client.GetAsync(url);
            // response.EnsureSuccessStatusCode();
            // string responseString = await response.Content.ReadAsStringAsync();

            // string responseString = await client.GetStringAsync(url);
            // issues = JsonSerializer.Deserialize<List<Issue>>(responseString) ?? new List<Issue>();

            issues = await JsonSerializer.DeserializeAsync<List<Issue>>(await client.GetStreamAsync(url)) ?? new List<Issue>();
        }
        catch(HttpRequestException ex)
        {
            Console.WriteLine("Something bad happened :'(");
        }
        return issues;
    }

    public Issue CreateIssue()
    {
        return new Issue();
    }
}