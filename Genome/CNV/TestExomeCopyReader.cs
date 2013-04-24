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
      Assert.AreEqual("1", actual[0].Chrom);
      Assert.AreEqual(string.Empty, actual[0].ItemName);
      Assert.AreEqual(16525012, actual[0].ChromStart);
      Assert.AreEqual(22469452, actual[0].ChromEnd);
      Assert.AreEqual(CNVType.DELETION, actual[0].ItemType);

      Assert.AreEqual("X2110_JP_11", actual.Last().FileName);
      Assert.AreEqual("11", actual.Last().Chrom);
      Assert.AreEqual(string.Empty, actual.Last().ItemName);
      Assert.AreEqual(32118842, actual.Last().ChromStart);
      Assert.AreEqual(32636537, actual.Last().ChromEnd);
      Assert.AreEqual(CNVType.DUPLICATION, actual.Last().ItemType);
    }
  }
}
