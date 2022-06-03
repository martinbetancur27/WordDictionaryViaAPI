using System.Text.Json;

//Source API: https://dictionaryapi.dev/
//Sorce JSON to C# Classes: https://json2csharp.com/

public class ApiDev : IDefinitionsApi
{
    public string UrlApi {get;}
    private bool _waswordfound = false;

    public ApiDev()
    {
        UrlApi = "https://api.dictionaryapi.dev/api/v2/entries/en/";
    }
    
    public async Task<List<string>> GetDefinitionsAsync(string wordToSearch)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage httpResponse;
        List<string> Final = new List<string>();
        httpResponse = await client.GetAsync(UrlApi + wordToSearch);
        List<Word> word = new List<Word>();

        if (httpResponse.IsSuccessStatusCode)
        {
            _waswordfound = true;
            
            var content = await httpResponse.Content.ReadAsStringAsync();

            //Enable case-insensitive property name matching with System.Text.Json
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            word =
            JsonSerializer.Deserialize<List<Word>>(content, options);

            //Logic API: The first element (array) is the element that I need
            word[0].Meanings[0].Definitions.ForEach(d =>
            {
                Final.Add("Def -> " + d.definition + "\nExam -> " + d.Example);
            });
                        
            return Final;
        }
        else
        {
            _waswordfound = false;
            return Final;
        }
    }

    public bool WasWordFound()
    {
        return _waswordfound;
    }
}