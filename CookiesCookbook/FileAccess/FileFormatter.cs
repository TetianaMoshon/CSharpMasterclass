namespace CookiesCookbook.FileAccess;

public static class FileFormatter
{
    public static string GetFormatString(FileFormat format)
    {
        return format switch
        {
            FileFormat.Json => "json",
            FileFormat.Xml => "xml",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

}