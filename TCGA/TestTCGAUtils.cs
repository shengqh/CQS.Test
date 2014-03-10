using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.TCGA
{
  [TestFixture]
  public class TestTCGAUtils
  {
    [Test]
    public void TestMethod()
    {
      var map = TCGAUtils.GetTumorDescriptionMap();
      Assert.AreEqual(33, map.Count);
      Assert.AreEqual("Acute Myeloid Leukemia", map["LAML"]);
      Assert.AreEqual("Uveal Melanoma", map["UVM"]);
    }
  }
}
