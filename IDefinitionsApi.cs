interface IDefinitionsApi
{
    Task<List<string>> GetDefinitionsAsync(string wordToSearch);
    public bool WasWordFound();
}