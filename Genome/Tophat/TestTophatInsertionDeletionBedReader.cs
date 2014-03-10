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

      Assert.AreEqual("1", lst[0].Seqname);
      Assert.AreEqual(13656, lst[0].Start);
      Assert.AreEqual(13658, lst[0].End);
      Assert.AreEqual("-", lst[0].Name);
      Assert.AreEqual(1, lst[0].Score);

      Assert.AreEqual("Y", lst[5].Seqname);
      Assert.AreEqual(59359640, lst[5].Start);
      Assert.AreEqual(59359642, lst[5].End);
      Assert.AreEqual("-", lst[5].Name);
      Assert.AreEqual(10, lst[5].Score);

      Assert.AreEqual("1", lst[6].Seqname);
      Assert.AreEqual(12663, lst[6].Start);
      Assert.AreEqual(12663, lst[6].End);
      Assert.AreEqual("GTC", lst[6].Name);
      Assert.AreEqual(1, lst[6].Score);

      Assert.AreEqual("Y", lst.Last().Seqname);
      Assert.AreEqual(59359023, lst.Last().Start);
      Assert.AreEqual(59359023, lst.Last().End);
      Assert.AreEqual("CCCC", lst.Last().Name);
      Assert.AreEqual(2, lst.Last().Score);
    }
  }
}
