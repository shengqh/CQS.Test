using CQS.Genome.Mapping;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQS.Genome.Sam
{
  [TestFixture]
  public class TestTrimedSAMAlignedItem
  {
    public void TestFill()
    {
      var samfile = @"../../data/01-018-Post_CTTGTA_slim.sam";
      var fastqfile = @"../../data/01-018-Post_CTTGTA_slim.fastq";

      var builder = new SAMAlignedItemCandidateBuilder(1);

      HashSet<string> totalQueryNames;
      var items = builder.Build<TrimedSAMAlignedItem>(samfile, out totalQueryNames);

      items.FillOriginalSequence(fastqfile);

      Assert.AreEqual("GAGGACCGGGATGGACATAC", items[0].OriginalSequence, items[0].Qname);
      Assert.AreEqual("ATACCGTCGTAGTCTTAACC", items[1].OriginalSequence, items[1].Qname);
      Assert.AreEqual("AAGGATTGACAGATTGAGAGC", items[2].OriginalSequence, items[2].Qname);

      Assert.AreEqual(items[0].OriginalSequence.Substring(2).Substring(0, items[0].OriginalSequence.Length - 5), items[0].Sequence, items[0].Qname);
      Assert.AreEqual(items[1].OriginalSequence.Substring(2).Substring(0, items[1].OriginalSequence.Length - 5), items[1].Sequence, items[1].Qname);
      Assert.AreEqual(items[2].OriginalSequence.Substring(2).Substring(0, items[2].OriginalSequence.Length - 5), items[2].Sequence, items[2].Qname);
    }
  }
}
