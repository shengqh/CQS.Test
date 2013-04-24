using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Pileup
{
  [TestFixture]
  public class TestPileupItemFisherExactTester
  {
    [Test]
    public void Test()
    {
      var item = new PileupItemFile().ReadFromFile("../../data/1_17716_G.wsm");

      Assert.AreEqual(8.20E-05, new PileupItemGroupTest().Test(item).PValue, 0.0000001);

      var cloneItem = item.CloneByFilter(m => m.Score >= 20);
      var res = new PileupItemGroupTest().Test(cloneItem);
      Assert.AreEqual(0.000228, res.PValue, 0.000001);
      Assert.AreEqual("G", res.SucceedName);
      Assert.AreEqual("A", res.FailedName);
      Assert.AreEqual("S1", res.Name1);
      Assert.AreEqual("S2", res.Name2);
    }
  }
}
