using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.GroSeq
{
  [TestFixture]
  public class TestPearsonCorrelationCalculator
  {
    [Test]
    public void TestCalculate()
    {
      Assert.AreEqual(0.5314685, new PearsonCorrelationCalculator().Calculate("../../data/pearson.data"), 0.0000001);
    }
  }
}
