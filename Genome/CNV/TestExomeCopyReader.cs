using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.CNV
{
  [TestFixture]
  public class TestExomeCopyReader
  {
    [Test]
    public void Test()
    {
      var actual = new ExomeCopyReader().ReadFromFile("../../data/ExomeCopy.tsv");
      Assert.AreEqual(5, actual.Count);

      Assert.AreEqual("X2110_JP_01", actual[0].FileName);
      Assert.AreEqual("1", actual[0].Seqname);
      Assert.AreEqual(string.Empty, actual[0].ItemName);
      Assert.AreEqual(16525012, actual[0].Start);
      Assert.AreEqual(22469452, actual[0].End);
      Assert.AreEqual(CNVType.DELETION, actual[0].ItemType);

      Assert.AreEqual("X2110_JP_11", actual.Last().FileName);
      Assert.AreEqual("11", actual.Last().Seqname);
      Assert.AreEqual(string.Empty, actual.Last().ItemName);
      Assert.AreEqual(32118842, actual.Last().Start);
      Assert.AreEqual(32636537, actual.Last().End);
      Assert.AreEqual(CNVType.DUPLICATION, actual.Last().ItemType);
    }
  }
}
