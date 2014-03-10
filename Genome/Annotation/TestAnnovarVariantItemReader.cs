using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Annotation
{
  [TestFixture]
  public class TestAnnovarVariantItemReader
  {
    [Test]
    public void TestRead()
    {
      var items = new AnnovarVariantItemReader().ReadFromFile("../../data/annovar.variant_function");
      Assert.AreEqual(5, items.Count);
      Assert.AreEqual("intergenic", items[0].VariantType);
      Assert.AreEqual("OR4F3(dist=196024),OR4F3(dist=56475)", items[0].VariantAnnotation);
      Assert.AreEqual("1", items[0].Seqname);
      Assert.AreEqual(564621, items[0].Start);
      Assert.AreEqual(564621, items[0].End);

      Assert.AreEqual("ncRNA_exonic", items.Last().VariantType);
      Assert.AreEqual("PDIA3P", items.Last().VariantAnnotation);
      Assert.AreEqual("1", items.Last().Seqname);
      Assert.AreEqual(146649854, items.Last().Start);
      Assert.AreEqual(146649854, items.Last().End);
    }
  }
}
