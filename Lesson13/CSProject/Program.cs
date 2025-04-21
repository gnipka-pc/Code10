using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using HttpClient client = new HttpClient();
        string url = "https://jsonplaceholder.org/posts/1";
        string response = await client.GetStringAsync(url);

        Dictionary<string, object> data = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

        foreach (var item in data)
        {
            System.Console.WriteLine($"{item.Key}: {item.Value}");
        }
        // System.Console.WriteLine(data["title"]);

        // System.Console.WriteLine(response);
    }
}