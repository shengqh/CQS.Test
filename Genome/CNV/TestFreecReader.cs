using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.CNV
{
  [TestFixture]
  public class TestFreecReader
  {
    [Test]
    public void Test()
    {
      var actual = new FreecReader().ReadFromFile("../../data/freec.call");
      Assert.AreEqual(15, actual.Count);

      Assert.AreEqual("1", actual[0].Chrom);
      Assert.AreEqual(string.Empty, actual[0].ItemName);
      Assert.AreEqual(0, actual[0].ChromStart);
      Assert.AreEqual(65493345, actual[0].ChromEnd);
      Assert.AreEqual(CNVType.DUPLICATION, actual[0].ItemType);
      Assert.AreEqual(3, actual[0].Score);

      Assert.AreEqual("2", actual.Last().Chrom);
      Assert.AreEqual(string.Empty, actual.Last().ItemName);
      Assert.AreEqual(209206230, actual.Last().ChromStart);
      Assert.AreEqual(218828475, actual.Last().ChromEnd);
      Assert.AreEqual(CNVType.DELETION, actual.Last().ItemType);
      Assert.AreEqual(0, actual.Last().Score);
    }
  }
}
