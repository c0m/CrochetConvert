using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

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

        private string ConvertToUS()
        {
            return InputBoxText.UKtoUS();
        }

        private string ConvertToUK()
        {
            return InputBoxText.UStoUK();
        }
    }
}
