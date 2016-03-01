using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CQS.Genome.Bed
{
  [TestFixture]
  public class TestMatchedBedItemFile
  {
    [Test]
    public void TestNext()
    {
      string filename = "../../../data/match.tsv";
      using (MatchedBedItemFile file = new MatchedBedItemFile(filename))
      {
        var item = file.Next();

        Assert.AreEqual("2", item.Seqname);
        Assert.AreEqual(73470225, item.Start);
        Assert.AreEqual(73470251, item.End);
        Assert.AreEqual("2-60", item.Name);
        Assert.AreEqual(1064, item.Score);
        Assert.AreEqual('+', item.Strand);

        Assert.AreEqual(3, item.Exons.Count);

        Assert.AreEqual("ENST00000469844;ENST00000540468;ENST00000539919;ENST00000258091;ENST00000461290;ENST00000399032;ENST00000409924;ENST00000537131;ENST00000473786", item.Exons[0].TranscriptId);
        Assert.AreEqual("processed_transcript", item.Exons[0].TranscriptType);
        Assert.IsTrue(item.Exons[0].RetainedIntron);
        Assert.AreEqual(3, item.Exons[0].IntronSize);
        Assert.AreEqual(2, item.Exons[0].Count);
        Assert.AreEqual(73470189, ((item.Exons[0]))[0].Start);
        Assert.AreEqual(73470256, ((item.Exons[0]))[0].End);
        Assert.AreEqual(73471124, ((item.Exons[0]))[1].Start);
        Assert.AreEqual(73471155, ((item.Exons[0]))[1].End);

        Assert.AreEqual("ENST00000471927;ENST00000480489", item.Exons[1].TranscriptId);
        Assert.AreEqual("processed_transcript", item.Exons[1].TranscriptType);
        Assert.IsTrue(item.Exons[1].RetainedIntron);
        Assert.AreEqual(16, item.Exons[1].IntronSize);
        Assert.AreEqual(1, item.Exons[1].Count);
        Assert.AreEqual(73470189, ((item.Exons[1]))[0].Start);
        Assert.AreEqual(73470288, ((item.Exons[1]))[0].End);

        Assert.AreEqual("ENST00000538797", item.Exons[2].TranscriptId);
        Assert.AreEqual("protein_coding", item.Exons[2].TranscriptType);
        Assert.IsFalse(item.Exons[2].RetainedIntron);
        Assert.AreEqual(0, item.Exons[2].IntronSize);
        Assert.AreEqual(2, item.Exons[2].Count);
        Assert.AreEqual(73470189, ((item.Exons[2]))[0].Start);
        Assert.AreEqual(73470256, ((item.Exons[2]))[0].End);
        Assert.AreEqual(73471671, ((item.Exons[2]))[1].Start);
        Assert.AreEqual(73471702, ((item.Exons[2]))[1].End);

        item = file.Next();
        Assert.IsNull(item);
      }
    }
  }
}
