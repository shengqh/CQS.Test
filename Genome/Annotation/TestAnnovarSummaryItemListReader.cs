using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Annotation
{
  [TestFixture]
  public class TestAnnovarSummaryItemListReader
  {
    [Test]
    public void Test()
    {
      var itemList = new AnnovarSummaryItemListReader().ReadFromFile("../../data/annovar.genome_summary.csv");
      Assert.AreEqual("Func,Gene,ExonicFunc,AAChange,Conserved,SegDup,ESP6500si_ALL,1000g2012apr_ALL,dbSNP137,AVSIFT,LJB_PhyloP,LJB_PhyloP_Pred,LJB_SIFT,LJB_SIFT_Pred,LJB_PolyPhen2,LJB_PolyPhen2_Pred,LJB_LRT,LJB_LRT_Pred,LJB_MutationTaster,LJB_MutationTaster_Pred,LJB_GERP++", itemList.SummaryHeaderInCsvFormat);
      Assert.AreEqual(9, itemList.Count);
      Assert.AreEqual("\"intergenic\",\"OR4F3(dist=196024),OR4F29(dist=56475)\",,,,\"1.00\",,,rs10458597,,,,,,,,,,,,", itemList[0].SummaryInCsvFormat);
      Assert.AreEqual("1", itemList[0].Seqname);
      Assert.AreEqual(564621, itemList[0].Start);
      Assert.AreEqual(564621, itemList[0].End);
    }
  }
}
