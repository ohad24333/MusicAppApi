using System.Text.RegularExpressions;

namespace MusicApp.WebApi
{
    public static class Regexes
    {
        public static Regex NameRegex = new Regex(@"[A-z]{2,10}",RegexOptions.IgnoreCase);
        public static Regex EmailRegex = new Regex(@"[A-z]{3,10}([A-z]|[0-9]){0,10}(\@gmail|\@yahoo|@walla)\.(net|com)", RegexOptions.IgnoreCase);
    }
}
