class SaveTxt: ISave
{
    private SaveTxt() 
    {}

    //Apply Singleton
    private static SaveTxt _instance;

    public static SaveTxt GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SaveTxt();
        }
        return _instance;
    }

    public async Task SaveAsync(string word, string meanings)
    {
        await File.WriteAllTextAsync(word + ".txt", meanings);
        Console.WriteLine("***** Saved *****");
        
    }
}