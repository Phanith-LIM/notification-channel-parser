using System.Text.RegularExpressions;

namespace notification_channel_parser
{
    internal abstract class Program
    {
        private static void Main()
        {
            const string input = "[QA][HAHA][BE] there is error";
            
            // Define pattern and validChannel
            List<string> validChannels = ["BE", "FE", "Urgent", "QA"];
            const string pattern = @"\[(.*?)\]";
            
            // Get the value that valid the pattern and channels
            List<string> foundChannels = GetMatches(input, pattern, validChannels);

            string result = "Receive channels: " + string.Join(", ", foundChannels);
            Console.WriteLine(result);
        }
        
        private static List<string> GetMatches(string input, string pattern, List<string> validChannel)
        {
            var matchesList = new List<string>();
            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                var value = match.Groups[1].Value;
                if (validChannel.Contains(value) && !matchesList.Contains(value))
                {
                    matchesList.Add(value);
                }
            }
            return matchesList.OrderBy(channel => channel).ToList();
        }
    }
}

