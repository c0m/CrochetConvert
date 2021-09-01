using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace CrochetConvert.Pages
{
    public partial class Index : ComponentBase
    {
        string OutputBoxText { get; set; } = string.Empty;

        private void CreateOutputText(int mode)
        {
            //since there are only two ways this can go we'll just if/else
            if(mode == 0) //US mode
            {
                OutputBoxText = ConvertToUS();
            }
            else //UK mode
            {
                OutputBoxText = ConvertToUK();
            }
        }

        private string ConvertToUS()
        {
            return "UStest";
        }

        private string ConvertToUK()
        {
            return "UKtest";
        }
    }
}
