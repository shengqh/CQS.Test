using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.TCGA.Microarray
{
  [TestFixture]
  public class TestLevel3MicroarrayDataTxtReader
  {
    [Test]
    public void TestReadAgilentFile()
    {
      var actual = new Level3MicroarrayDataTxtReader().ReadFromFile("../../data/US82800149_251976011805_S01_GE2_105_Dec08.txt_lmean.out.logratio.gene.tcga_level3.data.txt");
      Assert.AreEqual(17814, actual.Values.Count);
      Assert.AreEqual("ELMO2", actual.Values.First().Name);
      Assert.AreEqual(1.21942, actual.Values.First().Value, 0.00001);
      Assert.AreEqual("CTSC", actual.Values.Last().Name);
      Assert.AreEqual(-1.201, actual.Values.Last().Value, 0.001);
      Assert.IsTrue(actual.IsLog2Value);

      var opn5 = actual.Values.Find(m => m.Name.Equals("OPN5"));
      Assert.NotNull(opn5);
      Assert.IsNaN(opn5.Value);
    }

    [Test]
    public void TestReadAffymetrixFile()
    {
      var actual = new Level3MicroarrayDataTxtReader().ReadFromFile("../../data/DURUM_p_TCGA_B22_23_Expr_HT_HG-U133A_96-HTA_A10_543742.level3.data.txt");
      Assert.AreEqual(12042, actual.Values.Count);
      Assert.AreEqual("AACS", actual.Values.First().Name);
      Assert.AreEqual(6.67288, actual.Values.First().Value, 0.00001);
      Assert.AreEqual("AQP7", actual.Values.Last().Name);
      Assert.AreEqual(3.61720, actual.Values.Last().Value, 0.001);
      Assert.IsFalse(actual.IsLog2Value);
    }
  }
}
