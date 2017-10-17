using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sixeyed.Extensions.Advanced.Demo2
{
    //has access to internal types of InternalClasses because this extension method class is in the same assembly
    internal static class InternalClassExtensions
    {
        public static string GetString0Upper(this Class0 obj)
        {
            return obj.GetString0().ToUpper();
        }

        public static string GetString1Upper(this Class1 obj)
        {
            return obj.GetString1().ToUpper();
        }

        public static string GetString2Upper(this Class1.Class2 obj)//can access internal Class2 through internal Class1
        {
            return obj.GetString2().ToUpper();
        }

        public static string GetString3Upper(this object obj)//Class3 is private, but we can access it by extending object and using reflection
        {
            var upper = string.Empty;
            var type3 = typeof(Class1.Class2).GetNestedType("Class3", BindingFlags.NonPublic);
            if (obj.GetType() == type3)
            {
                var method = type3.GetMethod("GetString3", BindingFlags.NonPublic | BindingFlags.Instance);
                var string3 = method.Invoke(obj, null) as string;
                upper = string3.ToUpper();
            }
            return upper;
        }
    }
}
