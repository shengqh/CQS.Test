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
      var file = "../../../data/1_17716_G.wsm";
      var item = new PileupItemFile().ReadFromFile(file);
      Assert.AreEqual("1", item.SequenceIdentifier);
      Assert.AreEqual(17716, item.Position);
      Assert.AreEqual('G', item.Nucleotide);
      Assert.AreEqual(2, item.Samples.Count);
      Assert.AreEqual(187, item.Samples[0].Count);
      Assert.AreEqual(103, item.Samples[1].Count);
      Assert.AreEqual("S1", item.Samples[0].SampleName);
      Assert.AreEqual("G", item.Samples[0][0].Event);
      Assert.AreEqual(20, item.Samples[0][0].Score);
      Assert.AreEqual(StrandType.FORWARD, item.Samples[0][0].Strand);
      Assert.AreEqual(PositionType.END, item.Samples[0][0].Position);
      Assert.AreEqual("25", item.Samples[0][0].PositionInRead);
    }

    [Test]
    public void TestWrite()
    {
      var file = "../../../data/1_17716_G.wsm";
      var item = new PileupItemFile().ReadFromFile(file);

      var filename = "../../../data/1_17716_G.wsm.tmp";
      new PileupItemFile().WriteToFile(filename, item);

      FileAssert.AreEqual(file, filename, "check file " + Path.GetFullPath(filename) + ", it should be identical to file " + Path.GetFullPath(file));
      File.Delete(filename);
    }
  }
}
