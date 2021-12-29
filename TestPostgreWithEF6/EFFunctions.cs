using TestPostgreWithEF6.Models;

namespace TestPostgreWithEF6;

public static class EFFunctions
{
    public static string ToString(string t) => throw new NotSupportedException("this should be add to context configration");
    public static bool Any(string t, string proName, string search, bool match) => throw new NotSupportedException("this should be add to context configration");
}