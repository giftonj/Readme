using System.Text;
using System.Text.Json;
using Readme_Generator.Models;

namespace Readme_Generator.Generators;

public class MistralClient
{
    private readonly HttpClient _httpClient;
    public MistralClient(string apiKey)
    {
        _httpClient = new HttpClient();
        
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    }

    public async Task<string> AskAsync(string prompt)
    {
        var request = new
        {
            model = "mistral-large-latest",
            messages = new[]
            {
                new
                {
                    role = "user",
                    content = prompt
                }
            }
        };

        var json = JsonSerializer.Serialize(request);

        var response = await _httpClient.PostAsync(
            "https://api.mistral.ai/v1/chat/completions",
            new StringContent(json, Encoding.UTF8, "application/json"));

        var responseJson = await response.Content.ReadAsStringAsync();
        
        var result = JsonSerializer.Deserialize<ChatResponse>(responseJson);

        //Console.WriteLine(response.StatusCode);
        //Console.WriteLine(responseJson);
        

        using var document = JsonDocument.Parse(responseJson);
        
        
        return document
            .RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString() ?? string.Empty;
    }
}