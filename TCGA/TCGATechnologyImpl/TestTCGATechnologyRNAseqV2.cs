using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace CQS.TCGA.TCGATechnologyImpl
{
  [TestFixture]
  public class TestTCGATechnologyRNAseqV2
  {
    [Test]
    public void TestReader()
    {
      var actual = new TCGATechnologyRNAseqV2().GetReader().ReadFromFile("../../data/unc.edu.37d223e3-aa7e-41dc-b530-bd3c8365ddd5.1196451.rsem.genes.normalized_results");
      Assert.AreEqual(20501, actual.Values.Count);
      Assert.AreEqual("A1BG", actual.Values.First().Name);
      Assert.AreEqual(23.6080, actual.Values.First().Value, 0.0001);
      Assert.AreEqual("tAKR", actual.Values.Last().Name);
      Assert.AreEqual(0.0000, actual.Values.Last().Value, 0.0001);
      Assert.IsTrue(actual.Values.All(m => !double.IsNaN(m.Value)));
    }

    [Test]
    public void TestGetFilename()
    {
      var actual = new TCGATechnologyRNAseqV2().GetCountFilename("../../data/unc.edu.37d223e3-aa7e-41dc-b530-bd3c8365ddd5.1196451.rsem.genes.normalized_results");
      Assert.AreEqual("unc.edu.37d223e3-aa7e-41dc-b530-bd3c8365ddd5.1196417.rsem.genes.results", Path.GetFileName(actual));

      actual = new TCGATechnologyRNAseqV2().GetCountFilename("../../data/unc.edu.37d223e3-aa7e-41dc-b530-bd3c8365ddd5.1196452.rsem.isoforms.normalized_results");
      Assert.AreEqual("unc.edu.37d223e3-aa7e-41dc-b530-bd3c8365ddd5.1196418.rsem.isoforms.results", Path.GetFileName(actual));
    }
  }
}
