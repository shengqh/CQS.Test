using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.GroSeq
{
  [TestFixture]
  public class TestPeakAnnotationItemFormat
  {
    public void TestRead()
    {
      var format = new PeakAnnotationItemFormat();
      var items = format.ReadFromFile("../../data/annotation-mergedpeaks-corrected-forscript.txt");
      Assert.AreEqual(6, items.Count);
      Assert.AreEqual("macs-mtgr1-eto2-1094", items[0].PeakId);
      Assert.AreEqual("chr3", items[0].Chromosome);
      Assert.AreEqual(51492749, items[0].Start);
      Assert.AreEqual(51492837, items[0].End);
      Assert.AreEqual('+', items[0].Strand);
      Assert.AreEqual("\"3' UTR (NM_001004176, exon 5 of 5)\"", items[0].Annotation);
      Assert.AreEqual("\"3' UTR (NM_001004176, exon 5 of 5)\"", items[0].DetailedAnnotation);
    }
  }
}
