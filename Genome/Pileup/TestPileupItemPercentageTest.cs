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
      //only sample2 will be used to do the test
      var f = new FisherExactTestResult();
      f.Sample1.Failed = 0;
      f.Sample1.Succeed = 0;
      f.Sample2.Failed = 3;
      f.Sample2.Succeed = 30;

      var t = new PileupItemTumorTest(1, 0.1);
      Assert.IsFalse(t.Accept(f));

      //test minimum percentage
      f.Sample2.Failed = 4;
      Assert.IsTrue(t.Accept(f));

      //test minimum reads
      t = new PileupItemTumorTest(5, 0.1);
      Assert.IsFalse(t.Accept(f));
    }
  }
}
