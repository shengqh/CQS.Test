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
      var map = GtfUtils.GetGeneIdNameMap("../../../data/Homo_sapiens.GRCh37.68.slim.gtf");
      Assert.AreEqual(15, map.Count);
      Assert.AreEqual("BX072566.1", map["ENSG00000237375"]);
      Assert.AreEqual("GART", map["ENSG00000262473"]);
    }

    [Test]
    public void TestCombineCoordinates()
    {
      var gtfs = new List<GtfItem>();
      gtfs.Add(new GtfItem() { Start = 1, End = 20 });
      gtfs.Add(new GtfItem() { Start = 101, End = 150 });
      gtfs.Add(new GtfItem() { Start = 11, End = 30 });
      gtfs.CombineCoordinates();
      Assert.AreEqual(2, gtfs.Count);
      Assert.AreEqual(1, gtfs[0].Start);
      Assert.AreEqual(30, gtfs[0].End);
      Assert.AreEqual(101, gtfs[1].Start);
      Assert.AreEqual(150, gtfs[1].End);
    }
  }
}
