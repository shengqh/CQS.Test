using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.BreastCancer
{
  [TestFixture]
  public class TestBreastCancerSampleItemFormat
  {
    public void TestRead()
    {
      var samples = new BreastCancerSampleItemFormat("Source Name").ReadFromFile("../../../data/E-TABM-158.sdrf.txt");
      Assert.AreEqual(130, samples.Count);
      var s = samples[0];
      Assert.AreEqual("A-AFFY-76", s.Platform);
      Assert.AreEqual("E-TABM-158", s.Dataset);
      Assert.AreEqual("LBL_POP_W405609.F03.CEL", s.Sample);
      Assert.AreEqual("s0100", s.SourceName);
      Assert.AreEqual(string.Empty, s.SampleTitle);
      Assert.AreEqual(string.Empty, s.Patient);
      Assert.AreEqual("breast cancer", s.Disease);
      Assert.AreEqual("Neg", s.FamilyHistory);
      Assert.AreEqual("1", s.Stage);
      Assert.AreEqual("3", s.Grade);
      Assert.AreEqual(StatusValue.POSITIVE, s.ER);
      Assert.AreEqual(StatusValue.POSITIVE, s.PR);
      Assert.AreEqual(StatusValue.NEGATIVE, s.HER2);
      Assert.AreEqual(StatusValue.NEGATIVE, s.P53);
      Assert.AreEqual(StatusValue.NEGATIVE, s.HormonalTherapy);
      Assert.AreEqual(StatusValue.NEGATIVE, s.ChemotherapyTreatment);
      Assert.AreEqual(StatusValue.POSITIVE, s.RadiationTreatment);
      Assert.AreEqual(StatusValue.NEGATIVE, s.Recurrence);
      Assert.AreEqual(StatusValue.NEGATIVE, s.AliveAtEndpoint);
    }

    public void TestRead2()
    {
      var samples = new BreastCancerSampleItemFormat("Source Name").ReadFromFile("../../../data/E-MTAB-365.sdrf.txt");
      Assert.AreEqual(1843, samples.Count);
      var s = samples[1];
      Assert.AreEqual("A-AFFY-44", s.Platform);
      Assert.AreEqual("E-MTAB-365", s.Dataset);
      Assert.AreEqual("170706-09.CEL", s.Sample);
      Assert.AreEqual("CIT_DSOA_101", s.SourceName);
      Assert.AreEqual(string.Empty, s.SampleTitle);
      Assert.AreEqual(string.Empty, s.Patient);
      Assert.AreEqual("breast carcinoma", s.Disease);
      Assert.AreEqual(StatusValue.NA, s.FamilyHistory);
      Assert.AreEqual(string.Empty, s.Stage);
      Assert.AreEqual(string.Empty, s.Grade);
      Assert.AreEqual(StatusValue.POSITIVE, s.ER);
      Assert.AreEqual(StatusValue.NEGATIVE, s.PR);
      Assert.AreEqual(StatusValue.NEGATIVE, s.HER2);
      Assert.AreEqual(StatusValue.NA, s.P53);
      Assert.AreEqual(StatusValue.NA, s.HormonalTherapy);
      Assert.AreEqual(StatusValue.NA, s.ChemotherapyTreatment);
      Assert.AreEqual(StatusValue.NA, s.RadiationTreatment);
      Assert.AreEqual(StatusValue.NA, s.Recurrence);
      Assert.AreEqual(StatusValue.NA, s.AliveAtEndpoint);
    }
    
  }
}
