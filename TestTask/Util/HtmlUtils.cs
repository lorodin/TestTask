using System.Text.RegularExpressions;

namespace TestTask.Util
{
    public static class HtmlUtils
    {
        private static string htmlPattern = @"<(.|\n)*?>";
        public static string ClearHtml(this string html)
        {
            if (string.IsNullOrEmpty(html)) return html;
            return Regex.Replace(html, htmlPattern, string.Empty);
        }

        public static bool IsHtml(this string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            return Regex.IsMatch(text, htmlPattern);
        }
    }
}