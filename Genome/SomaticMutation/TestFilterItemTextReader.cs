using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CQS.Genome.SomaticMutation
{
  [TestFixture]
  public class TestFilterItemTextReader
  {
    [Test]
    public void TestReadFromFile()
    {
      var items = new FilterItemTextFormat().ReadFromFile("../../../data/TCGA-A7-A0D9-DNA-TP-NB.tsv");
      Assert.AreEqual(117, items.Count);
      Assert.AreEqual("1", items[0].Chr);
      Assert.AreEqual("37568524", items[0].Start);
      Assert.AreEqual("37568524", items[0].End);
      Assert.AreEqual("A", items[0].MajorAllele);
      Assert.AreEqual("G", items[0].MinorAllele);
      Assert.AreEqual("a", items[0].ReferenceAllele);
      Assert.AreEqual("14", items[0].NormalMajorCount);
      Assert.AreEqual("0", items[0].NormalMinorCount);
      Assert.AreEqual("7", items[0].TumorMajorCount);
      Assert.AreEqual("5", items[0].TumorMinorCount);
      Assert.AreEqual("0.0120401337792642", items[0].FisherGroup);
      Assert.AreEqual("1", items[0].FisherNormal);
      Assert.AreEqual("TRUE", items[0].BrglmConverged);
      Assert.AreEqual("0.0559533239203086", items[0].BrglmGroup);
      Assert.AreEqual("", items[0].BrglmScore);
      Assert.AreEqual("", items[0].BrglmStrand);
      Assert.AreEqual("", items[0].BrglmPosition);
      Assert.AreEqual("0.0891174471997679", items[0].BrglmGroupFdr);
      Assert.AreEqual("GLM_FDR", items[0].Filter);
      Assert.AreEqual("1_37568524_a_A_G_14_0_7_5_1.2E-02", items[0].Identity);
    }
  }
}
