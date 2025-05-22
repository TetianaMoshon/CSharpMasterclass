namespace CookiesCookbook.DataAccess;

public abstract class StringsRepo: IStringsRepo
{
    protected abstract List<string> TextToStrings(string text);
    
    protected abstract string StringsToText(List<string> strings);
    
    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var text = File.ReadAllText(filePath);
            return TextToStrings(text);
        }
        return new List<string>();
    }
    
    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, StringsToText(strings));
    }
}