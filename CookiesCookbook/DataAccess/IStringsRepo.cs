namespace CookiesCookbook.DataAccess;

public interface IStringsRepo
{
    List<string> Read(string filePath);
    void Write(string filePath, List<string> strings);
}