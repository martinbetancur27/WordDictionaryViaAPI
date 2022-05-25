public class Word
{
    //I'll make an exception because the class is also called Word.
    public string word { get; set; }
    public string Phonetic { get; set; }
    public List<Phonetic> Phonetics { get; set; }
    public List<Meaning> Meanings { get; set; }
    public License License { get; set; }
    public List<string> SourceUrls { get; set; }
}