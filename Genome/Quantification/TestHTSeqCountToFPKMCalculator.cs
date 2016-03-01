using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CQS.Genome.Mapping;

namespace CQS.Genome.Quantification
{
  [TestFixture]
  public class TestHTSeqCountToFPKMCalculator
  {
    [Test]
    public void TestCalculateFPKMWithSampleReads()
    {
      var options = new HTSeqCountToFPKMCalculatorOptions()
      {
        InputFile = "../../../data/genetable.tsv",
        GeneLengthFile = "../../../data/genetable.tsv.length",
        SampleReadsFile = "../../../data/genetable.tsv.sample"
      };

      double[] s1;
      double[] s2;

      var actuals = new HTSeqCountToFPKMCalculator(options).CalculateFPKM(out s1, out s2);
      var sampleReads = 100000000.0;
      var geneLength = 2968.0;
      var originalCount = 128.0;

      var expect = originalCount / ((sampleReads / 1000000) * (geneLength / 1000));
      Assert.AreEqual(expect, actuals.Count[0, 0], 0.0001);
    }

    [Test]
    public void TestCalculateFPKMWithoutSampleReads()
    {
      var options = new HTSeqCountToFPKMCalculatorOptions()
      {
        InputFile = "../../../data/genetable.tsv",
        GeneLengthFile = "../../../data/genetable.tsv.length",
      };

      double[] s1;
      double[] s2;

      var actuals = new HTSeqCountToFPKMCalculator(options).CalculateFPKM(out s1, out s2);
      var sampleReads = 138.0;
      var geneLength = 2968.0;
      var originalCount = 128.0;

      var expect = originalCount / ((sampleReads / 1000000) * (geneLength / 1000));
      Assert.AreEqual(expect, actuals.Count[0, 0], 0.0001);
    }
  }
}
