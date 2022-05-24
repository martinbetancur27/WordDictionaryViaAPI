using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;


Console.WriteLine("Input the word");
string wordToSearch = Console.ReadLine();

string url = "https://api.dictionaryapi.dev/api/v2/entries/en/";

HttpClient client = new HttpClient();

var httpResponse = await client.GetAsync(url + wordToSearch);

if (httpResponse.IsSuccessStatusCode)
{
    var content = await httpResponse.Content.ReadAsStringAsync();

 /*   //Enable case-insensitive property name matching with System.Text.Json
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };*/

    List<Word> resultWord =
    JsonSerializer.Deserialize<List<Word>>(content);

    var firstElement = resultWord.First();
    var listMeaning = firstElement.meanings;
    var listDefinitions = listMeaning[0].definitions;

    foreach (var word in listDefinitions)
    {
        Console.WriteLine(" ******* Definition and Example *******\n");
        Console.WriteLine("--> " + word.definition + "\n");
        Console.WriteLine("--> " + word.example + "\n");
    }

    Console.WriteLine("\n*** You know the meaning of --> " + wordToSearch + "***");

}