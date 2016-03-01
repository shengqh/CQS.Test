using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.TCGA.TCGATechnologyImpl
{
  [TestFixture]
  public class TestFindParticipantMicroarray
  {
    [Test]
    public void TestFind()
    {
      var finder = new FindParticipantMicroarray("../../../data/unc.edu_BRCA.AgilentG4502A_07_3.sdrf.txt");
      Assert.AreEqual("TCGA-AO-A03P-01A", finder.FindParticipant("US82800149_251976011805_S01_GE2_105_Dec08.txt_lmean.out.logratio.gene.tcga_level3.data.txt"));

      //data contains sample without used in TCGA
      finder = new FindParticipantMicroarray("../../../data/broad.mit.edu_LUSC.HT_HG-U133A.sdrf.txt");
      Assert.AreEqual("TCGA-21-1080-01A", finder.FindParticipant("DURUM_p_TCGA_B22_23_Expr_HT_HG-U133A_96-HTA_A10_543742.level3.data.txt"));
    }
  }
}
