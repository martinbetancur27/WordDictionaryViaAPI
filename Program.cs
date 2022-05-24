using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;


Console.WriteLine("Input the word");
string word = Console.ReadLine();

string url = "https://api.dictionaryapi.dev/api/v2/entries/en/";

HttpClient client = new HttpClient();

var httpResponse = await client.GetAsync(url + word);

if (httpResponse.IsSuccessStatusCode)
{
    var content = await httpResponse.Content.ReadAsStringAsync();

    Console.WriteLine(content);
}