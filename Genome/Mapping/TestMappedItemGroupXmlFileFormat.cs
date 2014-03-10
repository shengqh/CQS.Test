using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Mapping
{
  [TestFixture]
  public class TestMappedItemGroupXmlFileFormat
  {
    [Test]
    public void Test()
    {
      var items = new MappedItemGroupXmlFileFormat().ReadFromFile("../../data/2570-KCV-01-19.bam.count.mapped.trna.xml");
      Assert.AreEqual(310, items.Count);
    }

    [Test]
    public void TestXml()
    {
      var items = new MappedItemGroupXmlFileFormat().ReadFromFile("../../data/mappedgroup.xml");
      Assert.AreEqual(2, items.Count);

      var query = items.GetQueries();
      Assert.AreEqual(1, query.Count);

      var sam = query[0];
      Assert.AreEqual(20, sam.Locations.Count);
      Assert.AreEqual(2, sam.QueryCount);

      Assert.AreEqual(2, items[0].Count);
      var s1 = items[0][0];
      var s2 = items[0][1];

      Assert.AreEqual(1, s1.MappedRegions.Count);
      Assert.AreEqual(2, s2.MappedRegions.Count);

      Assert.AreEqual(2, items[0].QueryCount);

      Assert.AreEqual(1.5, items[0].EstimateCount);

      Assert.AreEqual(2, items[1].QueryCount);
      Assert.AreEqual(0.5, items[1].EstimateCount);
    }

  }
}
