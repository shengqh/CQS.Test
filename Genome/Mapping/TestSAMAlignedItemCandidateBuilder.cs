using CQS.Genome.Mapping;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQS.Genome.Sam
{
  [TestFixture]
  public class TestSAMAlignedItemCandidateBuilder
  {
    public void TestRead()
    {
      var filename = @"../../../data/01-018-Post_CTTGTA_slim.sam";

      var builder = new SAMAlignedItemCandidateBuilder(1);

      HashSet<string> totalQueryNames;
      var items = builder.Build<TrimedSAMAlignedItem>(filename, out totalQueryNames);

      Assert.AreEqual(3, items.Count);

      Assert.AreEqual("HWI-ST508:279:D2BAFACXX:5:1101:12662:2102", items[0].Qname);
      Assert.AreEqual("HWI-ST508:279:D2BAFACXX:5:1101:16014:2180", items[1].Qname);
      Assert.AreEqual("HWI-ST508:279:D2BAFACXX:5:1101:20077:2189", items[2].Qname);

      Assert.AreEqual(7, items[0].Locations.Count);
      Assert.AreEqual(6, items[1].Locations.Count);
      Assert.AreEqual(1, items[2].Locations.Count);
    }
  }
}
