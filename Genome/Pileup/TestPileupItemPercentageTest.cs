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
      var t = new PileupItemPercentageTest(0.1);
      var f = new FisherExactTestResult()
      {
        FailedCount1 = 2,
        SucceedCount1 = 18,
        FailedCount2 = 0,
        SucceedCount2 = 30
      };

      //only sample2 will be used to do the test
      Assert.IsFalse(t.Accept(f));

      f.FailedCount1 = 1;
      Assert.IsFalse(t.Accept(f));

      f.FailedCount2 = 4;
      Assert.IsTrue(t.Accept(f));
    }
  }
}
