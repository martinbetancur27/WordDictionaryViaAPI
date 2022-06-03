bool makeSearch = true;
string? wordToSearch;
bool saveSearch = false;
string result;
IDefinitionsApi searchByApi = new ApiDev();
Task<List<string>> definitions;

while (makeSearch)
{
    try
    {
        Console.WriteLine("> Input the word: ");
        wordToSearch = Console.ReadLine();

        definitions = searchByApi.GetDefinitionsAsync(wordToSearch);
        await definitions;

        if (searchByApi.WasWordFound())
        {
            result = "*** " + wordToSearch.ToUpper() + " ***\n";

            foreach (var definition in await definitions)
            {
                result += "\n" + definition + "\n";
            }

            Console.WriteLine(result);

            Console.WriteLine("\n*** Congratulations, You know the meaning of " + wordToSearch + " ***");

            Console.WriteLine("\n> Do you want to save your search to a file? Enter y/n");
            saveSearch = Console.ReadLine() == "y" ? true : false;

            if(saveSearch)
            {
                try
                {
                    ISave saveWord = SaveTxt.GetInstance();
                    await saveWord.SaveAsync(wordToSearch, result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Sorry, can't save: " + ex.Message);
                }
            }
        }
        else
        {
            Console.WriteLine("The word not exists in the dictionary");
        }

        Console.WriteLine("\n> Do you want to perform another search? Enter y/n");
        makeSearch = Console.ReadLine() == "y" ? true : false;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Sorry, the program not work. " + ex.Message);
        makeSearch = false;
    }
}