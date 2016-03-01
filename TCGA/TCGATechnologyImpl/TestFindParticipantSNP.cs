using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.TCGA.TCGATechnologyImpl
{
  [TestFixture]
  public class TestFindParticipantSNP
  {
    [Test]
    public void TestFind()
    {
      var finder = new FindParticipantSNP("../../../data/broad.mit.edu_BRCA.Genome_Wide_SNP_6.sdrf.txt");
      Assert.AreEqual("TCGA-A8-A06R-01A", finder.FindParticipant("CUSKS_p_TCGAb47_SNP_1N_GenomeWideSNP_6_A02_628278.hg19.seg.txt"));
    }
  }
}
