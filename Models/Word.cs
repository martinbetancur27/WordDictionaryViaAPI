public class Word
{
    public string word { get; set; }
    public string phonetic { get; set; }
    public List<Phonetic> phonetics { get; set; }
    public List<Meaning> meanings { get; set; }
    public License license { get; set; }
    public List<string> sourceUrls { get; set; }
}