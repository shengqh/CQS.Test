using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.QC
{
  [TestFixture]
  public class TestRNASeQCItemReader
  {
    [Test]
    public void Test()
    {
      var items = new RNASeQCItemReader().ReadFromFile("../../../data/rnaseqc_metrics.tsv");
      Assert.AreEqual(19, items.Count);
      Assert.AreEqual("G1_7071", items[0].Sample);
      Assert.AreEqual(2437915, items[0].AlternativeAlignments);
      Assert.AreEqual(69485233, items[0].MappedUnique);
      Assert.AreEqual(0.002318971, items[0].BaseMismatchRate);
      Assert.AreEqual(33526847, items[0].MappedPairs);
      Assert.AreEqual(218, items[0].FragmentLengthMean);
      Assert.AreEqual(205, items[0].FragmentLengthStdDev);
      Assert.AreEqual(1094795, items[0].ChimericPairs);
      Assert.AreEqual(0.9299, items[0].IntragenicRate, 0.0001);
      Assert.AreEqual(0.0879, items[0].IntronicRate, 0.0001);
      Assert.AreEqual(0.8420, items[0].ExonicRate, 0.0001);
      Assert.AreEqual(99, items[0].ReadLength);
      Assert.AreEqual(134191, items[0].TranscriptsDetected);
      Assert.AreEqual(23641, items[0].GenesDetected);
      Assert.AreEqual(56.24, items[0].MeanPerBaseCoverage, 0.01);
      Assert.AreEqual(0.8420, items[0].ExpressionProfilingEfficiency, 0.01);
    }
  }
}
