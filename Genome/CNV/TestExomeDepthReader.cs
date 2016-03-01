using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.CNV
{
  [TestFixture]
  public class TestExomeDepthReader
  {
    [Test]
    public void Test()
    {
      var actual = new ExomeDepthReader().ReadFromFile("../../../data/ExomeDepth.tsv");
      Assert.AreEqual(5, actual.Count);

      Assert.AreEqual("1", actual[0].Seqname);
      Assert.AreEqual(string.Empty, actual[0].ItemName);
      Assert.AreEqual(25611071, actual[0].Start);
      Assert.AreEqual(25655602, actual[0].End);
      Assert.AreEqual(CNVType.DUPLICATION, actual[0].ItemType);

      Assert.AreEqual("2", actual.Last().Seqname);
      Assert.AreEqual(string.Empty, actual.Last().ItemName);
      Assert.AreEqual(196743865, actual.Last().Start);
      Assert.AreEqual(196801229, actual.Last().End);
      Assert.AreEqual(CNVType.DELETION, actual.Last().ItemType);
    }
  }
}
