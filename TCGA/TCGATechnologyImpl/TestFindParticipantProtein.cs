using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.TCGA.TCGATechnologyImpl
{
  [TestFixture]
  public class TestFindParticipantProtein
  {
    [Test]
    public void TestFind()
    {
      var finder = new FindParticipantProtein("../../../data/nationwidechildrens.org_biospecimen_shipment_portion_brca.txt");
      Assert.AreEqual("TCGA-AO-A03N-01B", finder.FindParticipant("mdanderson.org_BRCA.MDA_RPPA_Core.protein_expression.Level_3.0a7af48e-5b73-42e8-acf6-a0bca1372cc4.txt"));
    }
  }
}
