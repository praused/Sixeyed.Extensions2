using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sixeyed.Extensions.Advanced.Demo5;

namespace Sixeyed.Extensions.Advanced.Tests.Demo5
{
    [TestClass]
    public class DecimalExtensionsTests
    {
        [TestMethod]
        public void ToString()
        {
            var input = 10.51M;
            Assert.AreEqual("10.5", input.ToString()); // fails because the class implementation of ToString is called
        }

        [TestMethod]
        public void ToStringRounded()
        {
            var input = 10.51M;
            Assert.AreEqual("10.5", input.ToStringRounded()); // passes, runs most specific extension
        }

        [TestMethod]
        public void ToStringRoundedIComparable()
        {
            var input = 10.51M;
            Assert.AreEqual("10.5", ((IComparable)input).ToStringRounded()); // fails because of cast
        }

        [TestMethod]
        public void ToStringRoundedIComparableOfDecimal()
        {
            var input = 10.51M;
            Assert.AreEqual("10.5", ((IComparable<decimal>)input).ToStringRounded()); // fails because of cast
        }
    }
}
