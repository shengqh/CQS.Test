using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Gtf
{
  [TestFixture]
  public class TestGtf2BedGeneIdBuilder
  {
    [Test]
    public void TestRead()
    {
      var options = new Gtf2BedGeneIdBuilderOptions()
      {
        InputFile = "../../../data/ENSMUSG00000089726.gtf"
      };

      var map = new Gtf2BedGeneIdBuilder(options).ReadBedItems();

      Assert.AreEqual(1, map.Count);
      Assert.AreEqual("ENSMUSG00000089726", map.Keys.First());
      var loc = map["ENSMUSG00000089726"];
      Assert.AreEqual(115042878, loc.Start);
      Assert.AreEqual(115046727, loc.End);
    }
  }
}
