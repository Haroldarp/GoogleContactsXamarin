using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleContactsXamarin.Services
{
    class ColorHelper
    {
        public static string ColorHex
        {
            get
            {
                Random random = new Random();
                List<string> colores = new List<string>()
                {
                   "#E9675E",
                   "#EB675B",
                   "#FDC633",
                   "#49CFE1",
                   "#AE5BF7"
                };

                return colores[random.Next(5)];
            }
        }
    }
}
