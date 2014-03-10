using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Gtf
{
  [TestFixture]
  public class TestGtfUtils
  {
    [Test]
    public void Test()
    {
      var map = GtfUtils.GetGeneIdNameMap("../../data/Homo_sapiens.GRCh37.68.slim.gtf");
      Assert.AreEqual(15, map.Count);
      Assert.AreEqual("BX072566.1", map["ENSG00000237375"]);
      Assert.AreEqual("GART", map["ENSG00000262473"]);
    }
  }
}
