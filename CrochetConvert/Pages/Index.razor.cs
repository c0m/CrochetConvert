using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace CrochetConvert.Pages
{
    public static class StringExtension
    {
        public static string UStoUK(this string s)
        {
            return new StringBuilder(s)
                //abbr replacement
                  .Replace("dc", "sc")
                  .Replace("sl st", "ss")
                  .Replace("htr", "hdc")
                  .Replace("dtr", "tr")
                  .Replace("ttr", "tr")
                  .Replace("tr", "dc")
                  .ToString();
        }

        public static string UKtoUS(this string s)
        {
            return new StringBuilder(s)
                  //abbr replacement
                  .Replace("sc", "dc")
                  .Replace("ss", "sl st")
                  .Replace("hdc", "htr")
                  .Replace("tr", "dtr")
                  .Replace("tr", "ttr")
                  .Replace("dc", "tr")
                  .ToString();
        }
    }

    public partial class Index : ComponentBase
    {
        string OutputBoxText { get; set; } = string.Empty;
        string InputBoxText { get; set; } = string.Empty;

        private void CreateOutputText(int mode)
        {
            //since there are only two ways this can go we'll just if/else
            if(mode == 0) //UK to US mode
            {
                OutputBoxText = ConvertToUS();
            }
            else //US to UK mode
            {
                OutputBoxText = ConvertToUK();
            }
        }

        public Dictionary<string, string> UStoUKDictionary = new Dictionary<string, string> {
            { "sl st", "ss" },
            { "sc", "dc" },
            { "hdc", "htr" },
            { "dc", "tr" },
            { "htr", "hdc" },
            { "tr", "dtr" },
            { "dtr", "trtr" },
            { "yo", "yoh" },
            { "gauge", "tension" }
        };

        public Dictionary<string, string> UKtoUSDictionary = new Dictionary<string, string> {
            { "ss", "sl st" },
            { "dc", "sc" },
            { "htr", "hdc" },
            { "tr", "dc" },
            { "hdc", "htr" },
            { "dtr", "tr" },
            { "trtr", "dtr" },
            { "yoh", "yo" },
            { "tension", "gauge" }
        };

        public string convertFromUSRegex= "/\b(?:sl st|sc|hdc|dc|htr|tr|dtr|yo|gauge)\b/gi";

        private string ConvertToUS()
        {
            return InputBoxText.UKtoUS();
        }

        private string ConvertToUK()
        {
            string output = InputBoxText;
            string pattern;
            foreach (string s in UStoUKDictionary.Keys)
            {
                pattern = @"\b" + s + @"\b"; // match on word boundaries
                output = Regex.Replace(output, pattern, UStoUKDictionary[s], RegexOptions.IgnoreCase);
            }
            return output;
        }
    }
}
