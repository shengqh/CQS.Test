using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Annotation
{
  [TestFixture]
  public class TestAnnovarGenomeSummaryItemReader
  {
    [Test]
    public void Test()
    {
      var items = new AnnovarGenomeSummaryItemReader().ReadFromFile("../../data/annovar.genome_summary.csv");
      Assert.AreEqual(9, items.Count);
      
      Assert.AreEqual("intergenic", items[0].Func);
      Assert.AreEqual("OR4F3(dist=196024),OR4F29(dist=56475)", items[0].GeneString);
      Assert.AreEqual(string.Empty, items[0].ExonicFunc);
      Assert.AreEqual("1", items[0].Seqname);
      Assert.AreEqual(564621, items[0].Start);
      Assert.AreEqual(564621, items[0].End);

      Assert.AreEqual("exonic", items[8].Func);
      Assert.AreEqual("KIAA1324", items[8].GeneString);
      Assert.AreEqual("synonymous SNV", items[8].ExonicFunc);
      Assert.AreEqual("1", items[8].Seqname);
      Assert.AreEqual(109737132, items[8].Start);
      Assert.AreEqual(109737132, items[8].End);
    }
  }
}
