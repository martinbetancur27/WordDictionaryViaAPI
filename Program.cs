using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;


string url = "https://api.dictionaryapi.dev/api/v2/entries/en/";
bool makeSearch = true;
string wordToSearch;

HttpClient client = new HttpClient();
HttpResponseMessage httpResponse;

while (makeSearch)
{
    Console.WriteLine("> Input the word: ");
    wordToSearch = Console.ReadLine();

    httpResponse = await client.GetAsync(url + wordToSearch);

    if (httpResponse.IsSuccessStatusCode)
    {
        string title = "\n ******* Definition and Example *******\n";
        bool saveSearch = false;

        string finalContent = "WORD: " + wordToSearch.ToUpper() + "\n";
        var content = await httpResponse.Content.ReadAsStringAsync();

        //Enable case-insensitive property name matching with System.Text.Json
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        List<Word> resultWord =
        JsonSerializer.Deserialize<List<Word>>(content, options);

        var firstElement = resultWord.First();
        var listMeaning = firstElement.Meanings;
        var listDefinitions = listMeaning[0].Definitions;

        foreach (var word in listDefinitions)
        {
            
            finalContent += title + "--> " + word.definition + "\n" + "--> " + word.Example + "\n";

        }

        Console.WriteLine(finalContent);

        Console.WriteLine("\n*** Congratulations, You know the meaning of " + wordToSearch + " ***");

        Console.WriteLine("\n> Do you want to save your search to a file? Enter y/n");
        saveSearch = Console.ReadLine() == "y" ? true : false;

        if(saveSearch)
        {
            try
            {
            await File.WriteAllTextAsync(wordToSearch + ".txt", finalContent);
            Console.WriteLine("***** Saved *****");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, can't save: " + ex.Message);
            }
        }
    }
    else
    {
        Console.WriteLine("The word "+ wordToSearch + " is not in our dictionary.");
    }
    
    Console.WriteLine("\n> Do you want to perform another search? Enter y/n");
    makeSearch = Console.ReadLine() == "y" ? true : false;

}