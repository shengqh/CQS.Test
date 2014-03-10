using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Annotation
{
  [TestFixture]
  public class TestAnnovarGenomeSummaryItem
  {
    [Test]
    public void TestSetGeneString()
    {
      AnnovarGenomeSummaryItem item = new AnnovarGenomeSummaryItem();
      item.GeneString = "TP53";
      Assert.AreEqual(1, item.Genes.Count);
      Assert.AreEqual("TP53", item.Genes[0].Name);

      item.GeneString = "FLJ20518(dist=2106),LOC401074(dist=2958)";
      Assert.AreEqual(2, item.Genes.Count);
      Assert.AreEqual("FLJ20518", item.Genes[0].Name);
      Assert.AreEqual("dist=2106", item.Genes[0].Annotation);
      Assert.AreEqual("LOC401074", item.Genes[1].Name);
      Assert.AreEqual("dist=2958", item.Genes[1].Annotation);

      item.GeneString = "FLJ20518(dist=2106),NONE(dist=NONE)";
      Assert.AreEqual(1, item.Genes.Count);
      Assert.AreEqual("FLJ20518", item.Genes[0].Name);
      Assert.AreEqual("dist=2106", item.Genes[0].Annotation);

      item.GeneString = "FRAS1(NM_025074:exon47:c.6584-2A>G)";
      Assert.AreEqual(1, item.Genes.Count);
      Assert.AreEqual("FRAS1", item.Genes[0].Name);
      Assert.AreEqual("NM_025074:exon47:c.6584-2A>G", item.Genes[0].Annotation);
      
    }
  }
}
