using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Annotation
{
  [TestFixture]
  public class TestAnnovarExonicVariantItemReader
  {
    [Test]
    public void TestRead()
    {
      var items = new AnnovarExonicVariantItemReader().ReadFromFile("../../data/annovar.exonic_variant_function");
      Assert.AreEqual(10, items.Count);
      Assert.AreEqual("nonsynonymous SNV", items[0].VariantType);
      Assert.AreEqual("AGRN:NM_198576:exon29:c.C5083A:p.L1695M,", items[0].VariantAnnotation);
      Assert.AreEqual("1", items[0].Chrom);
      Assert.AreEqual(985913, items[0].ChromStart);
      Assert.AreEqual(985913, items[0].ChromEnd);

      Assert.AreEqual("synonymous SNV", items[9].VariantType);
      Assert.AreEqual("NBPF3:NM_032264:exon13:c.T1567C:p.L523L,", items[9].VariantAnnotation);
      Assert.AreEqual("1", items[9].Chrom);
      Assert.AreEqual(21808223, items[9].ChromStart);
      Assert.AreEqual(21808223, items[9].ChromEnd);
    }
  }
}
