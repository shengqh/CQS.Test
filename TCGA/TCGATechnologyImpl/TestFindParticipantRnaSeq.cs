using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.TCGA.TCGATechnologyImpl
{
  [TestFixture]
  public class TestFindParticipantRnaSeq
  {
    [Test]
    public void TestFind()
    {
      var finder = new FindParticipantRnaSeq("../../../data/unc.edu_BRCA.IlluminaHiSeq_RNASeq.2.sdrf.txt");
      Assert.AreEqual("TCGA-BH-A0W3-01A", finder.FindParticipant("UNCID_375222.TCGA-BH-A0W3-01A-11R-A109-07.110607_UNC11-SN627_0100_AD0CT7ABXX.2.trimmed.annotated.translated_to_genomic.spljxn.quantification.txt"));
    }
  }
}
