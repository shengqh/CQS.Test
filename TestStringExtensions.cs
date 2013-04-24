using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS
{
  [TestFixture]
  public class TestStringExtensions
  {
    [Test]
    public void TestStringBefore()
    {
      Assert.AreEqual("ABC", "ABC:DEF".StringBefore(":"));
      Assert.AreEqual("ABCDEF", "ABCDEF".StringBefore(":"));
    }

    [Test]
    public void TestStringAfter()
    {
      Assert.AreEqual("DEF", "ABC:DEF".StringAfter(":"));
      Assert.AreEqual("ABCDEF", "ABCDEF".StringAfter(":"));
    }
  }
}
