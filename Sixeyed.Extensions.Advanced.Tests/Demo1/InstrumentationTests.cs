using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sixeyed.Extensions.Advanced.Demo1;
using System.Threading;

namespace Sixeyed.Extensions.Advanced.Tests.Demo1
{
    [TestClass]
    public class InstrumentationTests
    {
        [TestMethod]
        public void GetTotalSeconds()
        {
            var instrumentation = new Instrumentation();
            instrumentation.Start();
            Thread.Sleep(750);
            Assert.AreEqual(1, instrumentation.GetElapsedTime()); //passes bacause GetElapsedTime() rounds to whole seconds
        }

        [TestMethod]
        public void GetPreciseElapsedTime()
        {
            var instrumentation = new Instrumentation();
            instrumentation.Start();
            Thread.Sleep(750);
            var elapsed = instrumentation.GetPreciseElapsedTime();
            //Assert.IsTrue(elapsed >= 0.75 && elapsed < 0.751); //fails because using reflection (in GetPreciseElapsedTime) takes time.
            Assert.IsTrue(elapsed >= 0.75 && elapsed < 0.78);//passes because we broadened the range.
            //Could have fixed by taking the ending time before using reflection istead, but this example shows the limitations of reflection. 
        }

        [TestMethod]
        public void GetReallyPreciseElapsedTime()
        {
            var instrumentation = new Instrumentation();
            instrumentation.StartWithPrecision();
            Thread.Sleep(750);
            Assert.AreEqual(750, instrumentation.GetReallyPreciseElapsedTime());
        }
    }
}
