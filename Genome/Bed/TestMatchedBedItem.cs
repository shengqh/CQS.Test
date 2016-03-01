using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Bed
{
  [TestFixture]
  public class TestMatchedBedItem
  {
    [Test]
    public void TestMergeExon1()
    {
      var item = new MatchedBedItem();

      MatchExon e1 = new MatchExon();
      e1.TranscriptId = "E1";
      e1.Add(new Location(1, 10));
      e1.Add(new Location(30, 40));

      MatchExon e2 = new MatchExon();
      e2.TranscriptId = "E2";
      e2.Add(new Location(1, 10));
      e2.Add(new Location(30, 40));

      MatchExon e3 = new MatchExon();
      e3.TranscriptId = "E3";
      e3.Add(new Location(30, 39));

      item.Exons.Add(e1);
      item.Exons.Add(e2);
      item.Exons.Add(e3);

      Assert.AreEqual(3, item.Exons.Count);
      item.MergeExon();
      Assert.AreEqual(1, item.Exons.Count);
      Assert.AreEqual("E1;E2", item.Exons[0].TranscriptId);
    }

    [Test]
    public void TestMergeExon2()
    {
      string filename = "../../../data/match.tsv";
      var item = new MatchedBedItemFile(filename).Next();
      Assert.AreEqual(3, item.Exons.Count);
      item.MergeExon();
      Assert.AreEqual(1, item.Exons.Count);
      Assert.AreEqual("ENST00000538797", item.Exons[0].TranscriptId);
    }
  }
}
