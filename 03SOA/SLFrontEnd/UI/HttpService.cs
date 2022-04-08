using Models;
using System.Text.Json;
using System.Text;

namespace UI;
public class HttpService
{
    private readonly string _apiBaseURL = "https://localhost:7223/api/";
    private HttpClient client = new HttpClient();

    public HttpService()
    {
        client.BaseAddress = new Uri(_apiBaseURL);
    }
    public async Task<List<Issue>> GetAllIssuesAsync()
    {
        List<Issue> issues = new List<Issue>();
        //First, we are going to assemble our url for the resource
        //2nd, we are going to send a GET request to the api endpoint
        //3rd, we are going to deserialize the response and return it to 
        //our caller as List<Issue>

        try
        {
            //One way to send GET request
            // HttpResponseMessage response = await client.GetAsync("Issues");
            // response.EnsureSuccessStatusCode();
            // string responseString = await response.Content.ReadAsStringAsync();

            // //Above 3 lines can be shorted to this by using this new helper method
            // string responseString = await client.GetStringAsync("Issues");

            // //Finally, deserialize the string into List<Issue>
            // issues = JsonSerializer.Deserialize<List<Issue>>(responseString) ?? new List<Issue>();

            issues = await JsonSerializer.DeserializeAsync<List<Issue>>(await client.GetStreamAsync("Issues")) ?? new List<Issue>();
        }
        catch(HttpRequestException ex)
        {
            Console.WriteLine("Something bad happened :'(");
        }
        return issues;
    }

    public async Task<Issue> CreateIssueAsync(Issue issueToCreate)
    {
        string serializedIssue = JsonSerializer.Serialize(issueToCreate);
        StringContent content = new StringContent(serializedIssue, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage response = await client.PostAsync("Issues", content);
            response.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<Issue>(await response.Content.ReadAsStreamAsync()) ?? new Issue();
        }
        catch(HttpRequestException)
        {
            throw;
        }
    }
}