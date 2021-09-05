using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace CrochetConvert.Pages
{
    public partial class Index : ComponentBase
    {
        string OutputBoxText { get; set; } = string.Empty;
        string InputBoxText { get; set; } = string.Empty;
        /// <summary>
        /// Check to see which button the user pressed, then convert text accordingly
        /// </summary>
        /// <param name="mode">Passed by the button</param>
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
        private readonly string convertToUKRegex = @"\b(sl st|sc|hdc|dc|htr|tr|dtr|yo|gauge)\b";    // bounded regex to find these words for the dictionary
        private readonly string convertToUSRegex = @"\b(ss|dc|htr|tr|hdc|dtr|trtr|yoh|tension)\b";
        /// <summary>
        /// This takes the text from the input box and converts the instructions to the US standard
        /// </summary>
        /// <returns>Converted text</returns>
        private string ConvertToUS()
        {
            string output = InputBoxText;
            Regex reg = new Regex(convertToUSRegex, RegexOptions.IgnoreCase);
            output = reg.Replace(output, match =>
            {
                return UKtoUSDictionary[match.ToString()];
            });
            return output;
        }
        /// <summary>
        /// This takes the text from the input box and converts the instructions to the UK standard
        /// </summary>
        /// <returns>Converted text</returns>
        private string ConvertToUK()
        {
            string output = InputBoxText;
            Regex reg = new Regex(convertToUKRegex, RegexOptions.IgnoreCase);
            output = reg.Replace(output, match =>
                            {
                                return UStoUKDictionary[match.ToString()];
                            });
            return output;
        }
    }
}
