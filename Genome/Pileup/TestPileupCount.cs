using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CQS.Genome.Sam;

namespace CQS.Genome.Pileup
{
  [TestFixture]
  public class TestPileupCount
  {
    [Test]
    public void TestAdd()
    {
      SAMAlignedItem item1 = new SAMAlignedItem()
      {
        Sequence = "CTCTTAGATCGATGTGGTGCTCCGGAAAAAA",
      };
      item1.AddLocation(new SAMAlignedLocation(item1)
      {
        Seqname  ="chr13",
        Cigar = "5S21M5S",
        MismatchPositions = "10T10",
        Start = 39979942,
        Sequence = "CTCTTAGATCGATGTGGTGCTCCGGAAAAAA"
      });

      SAMAlignedItem item2 = new SAMAlignedItem()
      {
        Sequence = "GATGTAGTGCTCCGGATTTTT"
      };
      item2.AddLocation(new SAMAlignedLocation(item2)
      {
        Seqname = "chr13",
        Cigar = "21M",
        MismatchPositions = "5T15",
        Start = 39979947,
        Sequence = "GATGTAGTGCTCCGGATTTTT"
      });

      List<PileupCount> all = new List<PileupCount>();

      PileupCountList count = new PileupCountList();
      var res1 = count.Add(item1, 2);
      Assert.AreEqual(0, res1.Count);

      var res2 = count.Add(item2, 3);
      Assert.AreEqual(5, res2.Count);
      all.AddRange(res2);

      for (int i = 0; i < res2.Count; i++)
      {
        Assert.AreEqual(item1.Sequence[5 + i], res2[i].Reference);
        Assert.AreEqual(item1.Sequence[5 + i], res2[i].First().Key);
        Assert.AreEqual(2, res2[i].First().Value);
        Assert.AreEqual(item1.Locations[0].Seqname, res2[i].Chromosome);
        Assert.AreEqual(item1.Pos + i, res2[i].Position);
      }

      item1.Locations[0].Seqname = "chr14";
      var res3 = count.Add(item1, 2);
      Assert.AreEqual(21, res3.Count);
      all.AddRange(res3);
      
      for (int i = 0; i < 16; i++)
      {
        if (i == 5)
        {
          Assert.AreEqual('T', res3[i].Reference);
          Assert.True(res3[i].ContainsKey('G'));
          Assert.AreEqual(2, res3[i]['G']);
          Assert.True(res3[i].ContainsKey('A'));
          Assert.AreEqual(3, res3[i]['A']);
        }
        else
        {
          Assert.AreEqual(item2.Sequence[i], res3[i].Reference);
          Assert.AreEqual(item2.Sequence[i], res3[i].First().Key);
          Assert.AreEqual(5, res3[i].First().Value);
        }
      }

      for (int i = 16; i < 21; i++)
      {
        Assert.AreEqual(item2.Sequence[i], res3[i].First().Key);
        Assert.AreEqual(3, res3[i].First().Value);
      }

      var res4 = count.Count;
      Assert.AreEqual(21, res4.Count);
      all.AddRange(res4);

      for (int i = 0; i < res4.Count; i++)
      {
        Assert.AreEqual(item1.Sequence[5 + i], res4[i].First().Key);
        Assert.AreEqual(2, res4[i].First().Value);
        Assert.AreEqual(item1.Locations[0].Seqname, res4[i].Chromosome);
        Assert.AreEqual(item1.Pos + i, res4[i].Position);
      }

      //all.ForEach(m => Output(m));
    }

    private static void Output(PileupCount pc)
    {
      Console.WriteLine("{0}:{1}, {2}, {3}", pc.Chromosome, pc.Position, pc.Reference, (from r in pc select string.Format("{0}:{1}", r.Key, r.Value)).Merge("; "));
    }
  }
}
