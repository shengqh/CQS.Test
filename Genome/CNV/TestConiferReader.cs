using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.CNV
{
  [TestFixture]
  public class TestConiferReader
  {
    [Test]
    public void Test()
    {
      var actual = new ConiferReader().ReadFromFile("../../../data/conifer.txt");
      Assert.AreEqual(15, actual.Count);

      Assert.AreEqual("2110_JP_06", actual[0].FileName);
      Assert.AreEqual("chr1", actual[0].Seqname);
      Assert.AreEqual(string.Empty, actual[0].ItemName);
      Assert.AreEqual(17017582, actual[0].Start);
      Assert.AreEqual(17030683, actual[0].End);
      Assert.AreEqual(CNVType.DUPLICATION, actual[0].ItemType);
      Assert.AreEqual(1.0, actual[0].Score, 0.000001);

      Assert.AreEqual("2110_JP_16", actual.Last().FileName);
      Assert.AreEqual("chrY", actual.Last().Seqname);
      Assert.AreEqual(string.Empty, actual.Last().ItemName);
      Assert.AreEqual(45803892, actual.Last().Start);
      Assert.AreEqual(45812492, actual.Last().End);
      Assert.AreEqual(CNVType.DELETION, actual.Last().ItemType);
      Assert.AreEqual(1.0, actual.Last().Score, 0.000001);
    }
  }
}
