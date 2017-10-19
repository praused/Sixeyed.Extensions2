using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Extensions
// disambiguate extension method with the same signature and priority by changing the namespace
{
    public static class DecimalExtensions2
    {        
        public static string ToStringRounded(this decimal input)
        {
            return Math.Round(input, 2).ToString();
        }
    }
}
