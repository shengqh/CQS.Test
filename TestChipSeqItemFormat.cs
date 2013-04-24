using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CQS.ChipSeq;

namespace CQS
{
  [TestFixture]
  public class TestChipSeqItemFormat
  {
    public void TestRead()
    {
      var format = new ChipSeqItemFormat();
      var items = format.ReadFromFile("../../data/ChipSeqComparisonResult.tsv");
      Assert.AreEqual(2029, items.Count);
      Assert.AreEqual("chrI", items[0].Chromosome);
      Assert.AreEqual(151, items[0].Start);
      Assert.AreEqual(550, items[0].End);
      Assert.AreEqual(0.92, items[0].ReadDensity, 0.01);
      Assert.AreEqual(368, items[0].TreatmentCount);
      Assert.AreEqual(37, items[0].ControlCount);
      Assert.AreEqual(6.5924354, items[0].EnrichmentFactor, 0.0000001);
      Assert.AreEqual("YAL067W-A", items[0].GeneSymbol);
      Assert.AreEqual("YAL067W-A",items[0].LongestTranscript);
      Assert.AreEqual("Upstream", items[0].OverlapType);
      Assert.AreEqual(-2130, items[0].DistanceToTSS);
    }
  }
}
