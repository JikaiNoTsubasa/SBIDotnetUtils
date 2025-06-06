using System;
using System.Text.RegularExpressions;
using SBIDotnetUtils.Core;

namespace SBIDotnetUtils.Extensions;

public static partial class StringEx
{
    public static string ToSlug(this string phrase)
    {
        string str = phrase.RemoveAccent().ToLower();

        str = MyRegex().Replace(str, ""); // invalid chars          
        str = MyRegex1().Replace(str, " ").Trim(); // convert multiple spaces into one space  
        str = MyRegex2().Replace(str, "-"); // hyphens  
        str = str.Trim(); // cut and trim it  

        return str;
    }

    public static string SplitCamelCase(this string phrase)
    {
        return MyRegex3().Replace(phrase, " $1").Trim();
    }

    public static string RemoveAccent(this string txt)
    {
        return CharConverter.RemoveDiacritics(txt);
    }

    [GeneratedRegex(@"[^a-z0-9\s-]")]
    private static partial Regex MyRegex();
    [GeneratedRegex(@"\s+")]
    private static partial Regex MyRegex1();
    [GeneratedRegex(@"\s")]
    private static partial Regex MyRegex2();
    [GeneratedRegex("([A-Z])", RegexOptions.Compiled)]
    private static partial Regex MyRegex3();
}
