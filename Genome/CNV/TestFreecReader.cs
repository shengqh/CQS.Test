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

      Assert.AreEqual("1", actual[0].Seqname);
      Assert.AreEqual(string.Empty, actual[0].ItemName);
      Assert.AreEqual(0, actual[0].Start);
      Assert.AreEqual(65493345, actual[0].End);
      Assert.AreEqual(CNVType.DUPLICATION, actual[0].ItemType);
      Assert.AreEqual(3, actual[0].Score);

      Assert.AreEqual("2", actual.Last().Seqname);
      Assert.AreEqual(string.Empty, actual.Last().ItemName);
      Assert.AreEqual(209206230, actual.Last().Start);
      Assert.AreEqual(218828475, actual.Last().End);
      Assert.AreEqual(CNVType.DELETION, actual.Last().ItemType);
      Assert.AreEqual(0, actual.Last().Score);
    }
  }
}
