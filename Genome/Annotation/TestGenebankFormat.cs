using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Annotation
{
  [TestFixture]
  public class TestGenebankFormat
  {
    [Test]
    public void Test()
    {
      var items = new GenebankFormat().ReadFromFile(@"..\..\data\genebank.txt");
      Assert.AreEqual(2, items.Count);

      Assert.AreEqual("CAPM01000001", items[0].Accession);
      Assert.AreEqual(1, items[0].Features.Count);
      Assert.AreEqual("source", items[0].Features[0].FeatureName);
      Assert.IsFalse(items[0].Features[0].IsComplement);
      Assert.AreEqual(1, items[0].Features[0].Start);
      Assert.AreEqual(932, items[0].Features[0].End);

      Assert.AreEqual("CAPM01000002", items[1].Accession);
      Assert.AreEqual(12, items[1].Features.Count);

      Assert.AreEqual("source", items[1].Features[0].FeatureName);
      Assert.IsTrue(items[1].Features[0].IsComplement);
      Assert.AreEqual(1, items[1].Features[0].Start);
      Assert.AreEqual(9258, items[1].Features[0].End);

      Assert.AreEqual("CDS", items[1].Features[1].FeatureName);
      Assert.IsFalse(items[1].Features[1].IsComplement);
      Assert.AreEqual(6, items[1].Features[1].Start);
      Assert.AreEqual(689, items[1].Features[1].End);
    }
  }
}
