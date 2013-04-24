using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace CQS.Genome.Pileup
{
  [TestFixture]
  public class TestPileupItemFile
  {
    [Test]
    public void TestRead()
    {
      var file = "../../data/1_17716_G.wsm";
      var item = new PileupItemFile().ReadFromFile(file);
      Assert.AreEqual("1", item.SequenceIdentifier);
      Assert.AreEqual(17716, item.Position);
      Assert.AreEqual('G', item.Nucleotide);
      Assert.AreEqual(2, item.Samples.Count);
      Assert.AreEqual(187, item.Samples[0].Count);
      Assert.AreEqual(103, item.Samples[1].Count);
    }

    [Test]
    public void TestWrite()
    {
      var file = "../../data/1_17716_G.wsm";
      var item = new PileupItemFile().ReadFromFile(file);

      var filename = "../../data/1_17716_G.wsm.tmp";
      new PileupItemFile().WriteToFile(filename, item);

      FileAssert.AreEqual(file, filename, "check file " + Path.GetFullPath(filename) + ", it should be identical to file " + Path.GetFullPath(file));
      File.Delete(filename);
    }
  }
}
