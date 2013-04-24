using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CQS.Genome.Bed;

namespace CQS.Genome.Tophat
{
  [TestFixture]
  public class TestTophatInsertionDeletionBedReader
  {
    [Test]
    public void TestRead()
    {
      var lst = new BedItemFile<InsertionDeletionItem>().ReadFromFile(@"../../data/tophat_deletions.bed");
      Assert.AreEqual(12, lst.Count);

      Assert.AreEqual("1", lst[0].Chrom);
      Assert.AreEqual(13656, lst[0].ChromStart);
      Assert.AreEqual(13658, lst[0].ChromEnd);
      Assert.AreEqual("-", lst[0].Name);
      Assert.AreEqual(1, lst[0].Score);

      Assert.AreEqual("Y", lst[5].Chrom);
      Assert.AreEqual(59359640, lst[5].ChromStart);
      Assert.AreEqual(59359642, lst[5].ChromEnd);
      Assert.AreEqual("-", lst[5].Name);
      Assert.AreEqual(10, lst[5].Score);

      Assert.AreEqual("1", lst[6].Chrom);
      Assert.AreEqual(12663, lst[6].ChromStart);
      Assert.AreEqual(12663, lst[6].ChromEnd);
      Assert.AreEqual("GTC", lst[6].Name);
      Assert.AreEqual(1, lst[6].Score);

      Assert.AreEqual("Y", lst.Last().Chrom);
      Assert.AreEqual(59359023, lst.Last().ChromStart);
      Assert.AreEqual(59359023, lst.Last().ChromEnd);
      Assert.AreEqual("CCCC", lst.Last().Name);
      Assert.AreEqual(2, lst.Last().Score);
    }
  }
}
