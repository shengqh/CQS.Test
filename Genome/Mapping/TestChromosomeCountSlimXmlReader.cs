using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CQS.Genome.Mapping;

namespace CQS.Genome.Mapping
{
  [TestFixture]
  public class TestChromosomeCountSlimXmlReader
  {
    [Test]
    public void Test()
    {
      var items = new ChromosomeCountSlimXmlReader().ReadFromFile(@"../../../data/chromosome_count.xml");
      Assert.AreEqual(2, items.Count);
      Assert.AreEqual(8589, items[0].Queries.Count);
      Assert.AreEqual(6584, items[1].Queries.Count);
      Assert.AreEqual(13713, items[0].Queries.Union(items[1].Queries).Distinct().Count());
    }
  }
}
