using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Annotation
{
  [TestFixture]
  public class TestGenebankFeature
  {
    [Test]
    public void Test()
    {
      GenebankFeature cds = new GenebankFeature();

      cds.Location = "141..539";
      Assert.IsFalse(cds.IsComplement);
      Assert.AreEqual(141, cds.Start);
      Assert.AreEqual(539, cds.End);

      cds.Location = "complement(141..539)";
      Assert.IsTrue(cds.IsComplement);
      Assert.AreEqual(141, cds.Start);
      Assert.AreEqual(539, cds.End);

      cds.Context = new List<string>();

      cds.FeatureName = "CDS";
      List<string> paragraph = cds.GetParagraph(false);
      Assert.AreEqual("     CDS             complement(141..539)", paragraph[0]);
      paragraph = cds.GetParagraph(true);
      Assert.AreEqual("FT   CDS             complement(141..539)", paragraph[0]);

      cds.FeatureName = "Contig";
      paragraph = cds.GetParagraph(false);
      Assert.AreEqual("     Contig          complement(141..539)", paragraph[0]);
      paragraph = cds.GetParagraph(true);
      Assert.AreEqual("FT   Contig          complement(141..539)", paragraph[0]);
    }
  }
}
