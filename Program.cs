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

    string title = "\n ******* Definition and Example *******\n";
    bool saveSearch = false;

    string finalContent = "WORD: " + wordToSearch.ToUpper() + "\n";
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
        
        finalContent += title + "--> " + word.definition + "\n" + "--> " + word.example + "\n";

    }

    Console.WriteLine(finalContent);

    Console.WriteLine("\n*** You know the meaning of --> " + wordToSearch + "***");

    Console.WriteLine("\nDo you want to save your search to a file? Enter y/n");
    saveSearch = Console.ReadLine() == "y" ? true : false;

    if(saveSearch)
    {
        try
        {
        await File.WriteAllTextAsync(wordToSearch + ".txt", finalContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Sorry, can't save: " + ex.Message);
        }
        
    }

}