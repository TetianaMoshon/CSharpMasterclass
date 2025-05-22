using System.Text.Json;

namespace CookiesCookbook.DataAccess;

public class StringsJsonRepo: StringsRepo
{
    protected override string StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToStrings(string text)
    {
        return JsonSerializer.Deserialize<List<string>>(text);
    }
}