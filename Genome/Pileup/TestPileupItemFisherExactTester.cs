using NUnit.Framework;

namespace CQS.Genome.Pileup
{
  [TestFixture]
  public class TestPileupItemFisherExactTester
  {
    [Test]
    public void Test()
    {
      var item = new PileupItemFile().ReadFromFile("../../../data/1_17716_G.wsm");

      Assert.AreEqual(8.20E-05, item.InitializeTable().CalculateTwoTailPValue(), 0.0000001);

      var cloneItem = item.CloneByFilter(m => m.Score >= 20);
      var res = cloneItem.InitializeTable();
      Assert.AreEqual(0.000228, res.CalculateTwoTailPValue(), 0.000001);
      Assert.AreEqual("G", res.SucceedName);
      Assert.AreEqual("A", res.FailedName);
      Assert.AreEqual("S1", res.Sample1.Name);
      Assert.AreEqual("S2", res.Sample2.Name);
    }
  }
}
