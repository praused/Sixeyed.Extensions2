using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace Sixeyed.Extensions.Advanced.Demo1
{
    public static  class InstrumentationExtensions
    {
        //since the Instrumentation class has a unique id, we can simulate its state here using this static collection.
        private static Dictionary<Guid, Stopwatch> _Stopwatches = new Dictionary<Guid, Stopwatch>();
        //There's no garbage collection for this extended state, so it will just grow continually. That's a concern.

        public static double GetPreciseElapsedTime(this Instrumentation instrumentation)
        {
            //var startedAt = instrumentation._startedAt; //can't do this because _startedAt is a private field.
            //try workaround using reflection...
            var fieldInfo = typeof(Instrumentation).GetField("_startedAt", BindingFlags.Instance | BindingFlags.NonPublic);
            var startedAt = (DateTime)fieldInfo.GetValue(instrumentation);
            return new TimeSpan(DateTime.Now.Ticks - startedAt.Ticks).TotalSeconds;
        }

        //We'll use this method instead of the original start method (on the Instrumentation class)
        public static void StartWithPrecision(this Instrumentation instrumentation)
        {
            _Stopwatches[instrumentation.Id] = Stopwatch.StartNew();
        }

        public static long GetReallyPreciseElapsedTime(this Instrumentation instrumentation)
        {
            return _Stopwatches[instrumentation.Id].ElapsedMilliseconds;
        }
    }
}
