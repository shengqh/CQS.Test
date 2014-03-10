using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CQS.Genome.Statistics;

namespace CQS.Genome.Pileup
{
  [TestFixture]
  public class TestPileupItemPercentageTest
  {
    [Test]
    public void TestAccept()
    {
      var t = new PileupItemTumorPercentageTest(0.1);
      var f = new FisherExactTestResult();
      f.Sample1.Failed = 2;
      f.Sample1.Succeed = 18;
      f.Sample2.Failed = 0;
      f.Sample2.Succeed = 30;

      //only sample2 will be used to do the test
      Assert.IsFalse(t.Accept(f));

      f.Sample1.Failed = 1;
      Assert.IsFalse(t.Accept(f));

      f.Sample2.Failed = 4;
      Assert.IsTrue(t.Accept(f));
    }
  }
}
