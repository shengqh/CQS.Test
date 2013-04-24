using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.TCGA.TCGATechnologyImpl
{
  [TestFixture]
  public class TestTCGATechnologyRNAseqV1
  {
    [Test]
    public void TestReader()
    {
      var actual = new TCGATechnologyRNAseqV1().GetReader().ReadFromFile("../../data/UNCID_375228.TCGA-BH-A0W3-01A-11R-A109-07.110607_UNC11-SN627_0100_AD0CT7ABXX.2.trimmed.annotated.gene.quantification.txt");
      Assert.AreEqual(20502, actual.Values.Count);
      Assert.AreEqual("A1BG", actual.Values.First().Name);
      Assert.AreEqual(2.8510, actual.Values.First().Value, 0.0001);
      Assert.AreEqual("tAKR", actual.Values.Last().Name);
      Assert.AreEqual(0.0874, actual.Values.Last().Value, 0.0001);
      Assert.IsTrue(actual.Values.All(m => !double.IsNaN(m.Value)));
    }
  }
}
