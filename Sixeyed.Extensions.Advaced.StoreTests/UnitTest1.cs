﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Sixeyed.Extensions.Advaced.StoreTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FormatWith()
        {
            Assert.AreEqual("Demo 4", "Demo {0}".FormatWith(4));
        }
    }
}
