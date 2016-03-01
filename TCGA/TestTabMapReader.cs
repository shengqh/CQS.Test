using NUnit.Framework;
using RCPA.Utils;

namespace CQS.TCGA
{
  [TestFixture]
  public class TestTabMapReader
  {
    [Test]
    public void TestRead()
    {
      var map = new MapReader("Derived Array Data File", "Comment [Aliquot Barcode]").ReadFromFile("../../../data/broad.mit.edu_BRCA.Genome_Wide_SNP_6.sdrf.txt");
      Assert.AreEqual(6789, map.Count);
      Assert.AreEqual("TCGA-A8-A06R-01A-11D-A011-01", map["CUSKS_p_TCGAb47_SNP_1N_GenomeWideSNP_6_A02_628278.hg18.seg.txt"]);
      Assert.AreEqual("TCGA-A8-A06R-01A-11D-A011-01", map["CUSKS_p_TCGAb47_SNP_1N_GenomeWideSNP_6_A02_628278.hg19.seg.txt"]);
      Assert.AreEqual("TCGA-A8-A06R-01A-11D-A011-01", map["CUSKS_p_TCGAb47_SNP_1N_GenomeWideSNP_6_A02_628278.nocnv_hg18.seg.txt"]);
      Assert.AreEqual("TCGA-A8-A06R-01A-11D-A011-01", map["CUSKS_p_TCGAb47_SNP_1N_GenomeWideSNP_6_A02_628278.nocnv_hg19.seg.txt"]);
    }
  }
}
