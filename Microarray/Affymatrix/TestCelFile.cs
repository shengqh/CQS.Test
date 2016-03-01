using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Microarray.Affymatrix
{
  [TestFixture]
  public class TestCelFile
  {
    public void TestGetChipType()
    {
      Assert.AreEqual("HG-U133_Plus_2", CelFile.GetChipType("../../../data/GSM540353_20091006-16.CEL"));
      Assert.AreEqual("HG-U133_Plus_2", CelFile.GetChipType("../../../data/GSM540135_080115-19.CEL"));
      Assert.AreEqual("HG-U133A", CelFile.GetChipType("../../../data/GSM107072.CEL"));
      Assert.AreEqual("HG-U133_Plus_2", CelFile.GetChipType("../../../data/GSM540108_160306-23.CEL"));
      Assert.AreEqual("HG-U133_Plus_2", CelFile.GetChipType("../../../data/GSM124994.CEL.gz"));
    }
  }
}
