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

        var data = new
        {
            id = 100,
            slug = "lorem-ipsum",
            url = "https://jsonplaceholder.org/posts/lorem-ipsum",
            title = "abc",
            content = "testtest",
            image = "https://dummyimage.com/800x430/FFFFFF/lorem-ipsum.png&text=jsonplaceholder.org",
            thumbnail = "https://dummyimage.com/200x200/FFFFFF/lorem-ipsum.png&text=jsonplaceholder.org",
            status = "published",
            category = "lorem",
            publishedAt = "04/02/2023 13:25:21",
            updatedAt = "14/03/2023 17:22:20",
            userId = 1
        };

        string json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            // string responseBody = await client.GetStringAsync(url + "00");

            // Dictionary<string, object> responseData = JsonSerializer.Deserialize<Dictionary<string, object>>(responseBody);

            // foreach (var item in responseData)
            // {
            //     System.Console.WriteLine($"{item.Key}: {item.Value}");
            // }
            // System.Console.WriteLine(responseData["title"]);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }


        // string response = await client.GetStringAsync(url);

        // Dictionary<string, object> data = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

        // foreach (var item in data)
        // {
        //     System.Console.WriteLine($"{item.Key}: {item.Value}");
        // }
        // System.Console.WriteLine(data["title"]);

        // System.Console.WriteLine(response);
    }
}